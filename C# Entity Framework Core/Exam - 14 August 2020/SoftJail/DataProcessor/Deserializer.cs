namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";
        public const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";
        public const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";
        public const string SuccessfullyImportedOfficerPrisoners = "Imported {0} ({1} prisoners)";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<DepartmentImportDto[]>(jsonString);
            var departemnts = new HashSet<Department>();

            var sb = new StringBuilder();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cells = new HashSet<Cell>();
                bool isCellValid = true;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isCellValid = false;
                        break;
                    }

                    var cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    cells.Add(cell);
                }

                if (!isCellValid)
                {
                    continue;
                }

                var departemnt = new Department
                {
                    Name = departmentDto.Name,
                    Cells = cells
                };

                departemnts.Add(departemnt);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, departemnt.Name, departemnt.Cells.Count));
            }

            context.Departments.AddRange(departemnts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<PrisonerImportDto[]>(jsonString);
            var prisoners = new HashSet<Prisoner>();

            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                                          CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDateDto;

                if (prisonerDto.ReleaseDate == null)
                {
                    releaseDateDto = null;
                }
                else if (DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                         CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate))
                {
                    releaseDateDto = releaseDate;
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var mails = new HashSet<Mail>();
                bool isMailValid = true;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    mails.Add(mail);
                }

                if (!isMailValid)
                {
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    CellId = prisonerDto.CellId,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDateDto,
                    Mails = mails
                };

                prisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerialiser = new XmlSerializer(typeof(OfficerImportDto[]), new XmlRootAttribute("Officers"));
            var sr = new StringReader(xmlString);
            var sb = new StringBuilder();

            OfficerImportDto[] officersDto = (OfficerImportDto[])xmlSerialiser.Deserialize(sr);
            var officers = new HashSet<Officer>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPositionValid = Enum.TryParse(officerDto.Position, out Position position);

                if (!isPositionValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isWeaponValid = Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                if (!isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId
                };

                var officerPrisoners = new HashSet<OfficerPrisoner>();

                foreach (int prisonerId in officerDto.Prisoners.Select(p => p.Id))
                {
                    var officerPrisoner = new OfficerPrisoner
                    {
                        OfficerId = officer.Id,
                        PrisonerId = prisonerId
                    };

                    officerPrisoners.Add(officerPrisoner);
                }

                officer.OfficerPrisoners = officerPrisoners;
                officers.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficerPrisoners, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}