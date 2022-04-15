namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesByGenres = context.Genres.Where(g => genreNames.Any(x => x == g.Name))
				                              .ToArray()
											  .Select(g => new
											  {
												 Id = g.Id,
												 Genre = g.Name,
												 Games = g.Games.Where(x => x.Purchases.Any())
												 .Select(game => new
												 {
                                                    Id = game.Id,
                                                    Title = game.Name,
                                                    Developer = game.Developer.Name,
                                                    Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name)),
                                                    Players = game.Purchases.Count
                                                })
                                                .OrderByDescending(game => game.Players)
                                                .ThenBy(game => game.Id)
                                                .ToArray(),
												 TotalPlayers = g.Games.Sum(s => s.Purchases.Count)
											  })
                                              .OrderByDescending(g => g.Games.Sum(s => s.Players))
                                              .ThenBy(g => g.Id)
                                              .ToArray();

			string result = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

			return result;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			StringBuilder sb = new StringBuilder();

			var xmlSerializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("Users"));
			var namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			using var sw = new StringWriter(sb);

			var usersWithPurchase = context.Users.Where(u => u.Cards.Any(c => c.Purchases.Any()))
												 .ToArray()
												 .Select(u => new UserExportDto
												 {
													 UserName = u.Username,
													 Purchases = context.Purchases
													 .ToArray()
													 .Where
														  (p => p.Card.User.Username == u.Username &&
														   p.Type.ToString() == storeType)
													.OrderBy(p => p.Date)
													.Select(p => new PurchaseExportDto
													 {
															CardNumber = p.Card.Number,
															Cvc = p.Card.Cvc,
															Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
															Game = new GameExportDto
															{
																Title = p.Game.Name,
																Genre = p.Game.Genre.Name,
																Price = p.Game.Price.ToString()
															}
													  })
													 .ToArray(),
												     TotalSpent = context.Purchases
													 .ToArray()                                   
					                                 .Where(p => p.Card.User.Username == u.Username && p.Type.ToString() == storeType)
						                             .Sum(u => u.Game.Price)
												 })
												 .Where(u => u.Purchases.Length > 0)
												 .OrderByDescending(u => u.TotalSpent)
												 .ThenBy(u => u.UserName)
												 .ToArray();

			xmlSerializer.Serialize(sw, usersWithPurchase, namespaces);

			return sb.ToString().TrimEnd();
        }
    }
}