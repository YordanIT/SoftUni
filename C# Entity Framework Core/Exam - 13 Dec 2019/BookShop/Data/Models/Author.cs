using BookShop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConst.AuthorNameMaxLenght)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(GlobalConst.AuthorNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}


