using BookShop.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookImportDto
    {
        [Required]
        [MinLength(GlobalConst.BookNameMinLenght)]
        [MaxLength(GlobalConst.BookNameMaxLenght)]
        public string Name { get; set; }

        public int Genre { get; set; }

        [Range(GlobalConst.BookPriceMinValue, GlobalConst.BookPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(GlobalConst.BookPagesMinValue, GlobalConst.BookPagesMaxValue)]
        public int Pages { get; set; }
        
        [Required]
        public string PublishedOn { get; set; }
    }
}


