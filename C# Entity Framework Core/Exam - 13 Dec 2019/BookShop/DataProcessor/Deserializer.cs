﻿namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(BookImportDto[]), new XmlRootAttribute("Books"));
            var sr = new StringReader(xmlString);

            BookImportDto[] booksDto = (BookImportDto[])xmlSerializer.Deserialize(sr);
            var books = new HashSet<Book>();

            foreach (var bookDto in booksDto)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (bookDto.Genre != 1 && bookDto.Genre != 2 && bookDto.Genre != 3)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
              
                bool isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", 
                                   CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOnDto);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = bookDto.Name,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    Genre = (Genre)bookDto.Genre,
                    PublishedOn = publishedOnDto
                };

                books.Add(book);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<AuthorImportDto[]>(jsonString);
            var authors = new HashSet<Author>();

            foreach (var authorDto in authorsDto)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isMailExist = context.Authors.Select(a => a.Email).Any(m => m == authorDto.Email);

                if (isMailExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

            var authorBooks = new HashSet<AuthorBook>();

                foreach (var bookDto in authorDto.Books)
                {
                    if (bookDto == null)
                    {
                        continue;
                    }

                    var book = context.Books.Find(bookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    authorBooks.Add(new AuthorBook 
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (authorBooks.Count < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                author.AuthorsBooks = authorBooks;
                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, 
                    $"{author.FirstName} {author.LastName}", author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}