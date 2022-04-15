namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToArray()
                                           .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                                           .Select(t => new
                                           {
                                               Name = t.Name,
                                               Halls = t.NumberOfHalls,
                                               TotalIncome = t.Tickets.
                                               Where(tt => tt.RowNumber >= 1
                                               && tt.RowNumber <= 5)
                                               .Sum(p => p.Price),
                                               Tickets = t.Tickets.Where(tt => tt.RowNumber >= 1
                                               && tt.RowNumber <= 5)
                                               .Select(tt => new
                                               {
                                                   Price = tt.Price,
                                                   RowNumber = tt.RowNumber
                                               })
                                               .OrderByDescending(tt => tt.Price)
                                               .ToArray()
                                           })
                                           .OrderByDescending(t => t.Halls)
                                           .ThenBy(t => t.Name)
                                           .ToArray();

            string result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays.Where(p => p.Rating <= rating)
                                     .OrderBy(p => p.Title)
                                     .ThenByDescending(p => p.Genre)
                                     .Select(p => new PlayExportDto
                                     {
                                         Title = p.Title,
                                         Duration = p.Duration.ToString("c"),
                                         Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                                         Genre = p.Genre.ToString(),
                                         Actors = p.Casts
                                         .Where(a => a.IsMainCharacter == true)
                                         .Select(a => new ActorExportDto 
                                         { 
                                             FullName = a.FullName,
                                             MainCharacter = $"Plays main character in '{p.Title}'."
                                         })
                                         .OrderByDescending(a => a.FullName)
                                         .ToArray()
                                     })
                                     .ToArray();

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(PlayExportDto[]), new XmlRootAttribute("Plays"));

            xmlSerializer.Serialize(sw, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
