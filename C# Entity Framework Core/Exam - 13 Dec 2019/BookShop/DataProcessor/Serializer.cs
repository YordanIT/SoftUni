namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors.ToArray()
                                         .Select(a => new
                                         {
                                             AuthorName = $"{a.FirstName} {a.LastName}",
                                             Books = a.AuthorsBooks
                                                .OrderByDescending(b => b.Book.Price)
                                                .Select(b => new
                                                {
                                                    BookName = b.Book.Name,
                                                    BookPrice = b.Book.Price.ToString("f2")
                                                }).ToArray()
                                         })
                                         .OrderByDescending(a => a.Books.Length)
                                         .ThenBy(a => a.AuthorName)
                                         .ToArray();

            string result = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books.Where(b => b.PublishedOn < date && (int)b.Genre == 3)
                                     .OrderByDescending(b => b.Pages)
                                     .ThenByDescending(b => b.PublishedOn)
                                     .Take(10)
                                     .ToArray()
                                     .Select(b => new BookExportDto
                                     {
                                         Name = b.Name,
                                         Pages = b.Pages,
                                         Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                                     })
                                     .ToArray();

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            
            var xmlSerializer = new XmlSerializer(typeof(BookExportDto[]), new XmlRootAttribute("Books"));

            xmlSerializer.Serialize(sw, books, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}