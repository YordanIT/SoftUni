using BookShop.Common;
using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(GlobalConst.BookNameMaxLenght)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Range(GlobalConst.BookPriceMinValue, GlobalConst.BookPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(GlobalConst.BookPagesMinValue, GlobalConst.BookPagesMaxValue)]
        public int Pages { get; set; }

        public DateTime PublishedOn { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}


