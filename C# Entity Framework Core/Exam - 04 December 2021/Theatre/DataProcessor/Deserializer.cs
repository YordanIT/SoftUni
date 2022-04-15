namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(PlayImportDto[]), new XmlRootAttribute("Plays"));
            var sr = new StringReader(xmlString);

            PlayImportDto[] playsDto = (PlayImportDto[])xmlSerializer.Deserialize(sr);
            var plays = new HashSet<Play>();

            foreach (var playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(playDto.Duration, "c", 
                    CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan durationDto);

                if (!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                TimeSpan oneHour = new TimeSpan(1, 00, 00);

                if(TimeSpan.Compare(durationDto, oneHour) == -1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(typeof(Genre), playDto.Genre, out object genreDto);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = playDto.Title,
                    Description = playDto.Description,
                    Duration = durationDto,
                    Genre = (Genre)genreDto,
                    Rating = playDto.Rating,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(CastImportDto[]), new XmlRootAttribute("Casts"));
            var sr = new StringReader(xmlString);

            CastImportDto[] castsDto = (CastImportDto[])xmlSerializer.Deserialize(sr);
            var casts = new HashSet<Cast>();

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isMainCharacterValid = Boolean.TryParse
                    (castDto.IsMainCharacter, out bool IsMainCharacterDto);

                if (!isMainCharacterValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = castDto.FullName,
                    PhoneNumber = castDto.PhoneNumber,
                    IsMainCharacter = IsMainCharacterDto,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, 
                                           cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var theatresDto = JsonConvert.DeserializeObject<TheatreImportDto[]>(jsonString);
            var theatres = new HashSet<Theatre>();

            foreach (var theatreDto in theatresDto)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var tickets = new HashSet<Ticket>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var play = context.Plays.Find(ticketDto.PlayId);

                    if (play == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = (sbyte)ticketDto.RowNumber,
                        Play = play 
                    });
                }

                var theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    Director = theatreDto.Director,
                    NumberOfHalls = (sbyte)theatreDto.NumberOfHalls,
                    Tickets = tickets
                };

                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();
         
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
