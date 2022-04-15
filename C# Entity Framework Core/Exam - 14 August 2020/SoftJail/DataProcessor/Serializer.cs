namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.Where(p => ids.Contains(p.Id))
                                             .ToArray()
                                             .Select(p => new
                                             {
                                                 Id = p.Id,
                                                 Name = p.FullName,
                                                 CellNumber = p.Cell.CellNumber,
                                                 Officers = p.PrisonerOfficers.Select(po => new
                                                 {
                                                     OfficerName = po.Officer.FullName,
                                                     Department = po.Officer.Department.Name
                                                 })
                                                 .OrderBy(po => po.OfficerName)
                                                 .ToArray(),
                                                 TotalOfficerSalary = p.PrisonerOfficers.Select(o => o.Officer.Salary).Sum()
                                             })
                                             .OrderBy(p => p.Name)
                                             .ThenBy(p => p.Id)
                                             .ToArray();

            string result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var sb = new StringBuilder();

            var xmlSerilizer = new XmlSerializer(typeof(PrisonerExportDto[]), new XmlRootAttribute("Prisoners"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using var sw = new StringWriter(sb);

            string[] names = prisonersNames.Split(',').ToArray();

            var prisoners = context.Prisoners.Where(p => names.Contains(p.FullName))
                                             .ToArray()
                                             .Select(p => new PrisonerExportDto
                                             {
                                                 Id = p.Id,
                                                 Name = p.FullName,
                                                 IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                                 EncryptedMessages = p.Mails.Select(m => new MessageExportDto
                                                 {
                                                     Description = Reverse(m.Description)
                                                 })
                                                 .ToArray()
                                             })
                                             .OrderBy(p => p.Name)
                                             .ThenBy(p => p.Id)
                                             .ToArray();

            xmlSerilizer.Serialize(sw, prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}