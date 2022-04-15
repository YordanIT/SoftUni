namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";
        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";
        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";
        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();

            var gamesDto = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDateDto;
                bool isRealiseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                              CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateDto);

                if (!isRealiseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDateDto
                };

                var developer = developers.FirstOrDefault(dev => dev.Name == gameDto.Developer);              
                if (developer == null)
                {
                    developer = new Developer { Name = gameDto.Developer };
                    developers.Add(developer);
                }
                game.Developer = developer;

                var genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre { Name = gameDto.Genre };
                    genres.Add(genre);
                }
                game.Genre = genre;

                foreach (var tagName in gameDto.Tags)
                {
                    if (string.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    var gameTag = tags.FirstOrDefault(t => t.Name == tagName);

                    if (gameTag == null)
                    {
                        gameTag = new Tag { Name = tagName };
                    }
                    tags.Add(gameTag);
                    game.GameTags.Add(new GameTag { Game = game, Tag = gameTag });
                }

                if (game.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var users = new List<User>();
            
            var usersDto = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!userDto.Cards.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                { 
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    TypeCard cardType;
                    bool isCardTypeValid = Enum.TryParse(cardDto.Type, true, out cardType);

                    if (!isCardTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    };

                    cards.Add(card);
                }

                var user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = cards
                };

                users.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(PurchaseImportDto[]), new XmlRootAttribute("Purchases"));
            using var sr = new StringReader(xmlString);

            PurchaseImportDto[] purchasesDto = (PurchaseImportDto[])xmlSerializer.Deserialize(sr);
            var purchases = new List<Purchase>();
            var sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType purchaseType;
                bool isPurchaseTypeValid = Enum.TryParse(purchaseDto.Type, true, out purchaseType);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime puchaseDate;
                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out puchaseDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                
                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.ProductKey,
                    Card = card,
                    Date = puchaseDate,
                    Game = game
                };

                purchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
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