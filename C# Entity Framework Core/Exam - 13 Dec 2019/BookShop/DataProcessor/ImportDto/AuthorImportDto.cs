using BookShop.Common;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorImportDto
    {
        [Required]
        [MinLength(GlobalConst.AuthorNameMinLenght)]
        [MaxLength(GlobalConst.AuthorNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConst.AuthorNameMinLenght)]
        [MaxLength(GlobalConst.AuthorNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConst.AuthorPhoneRegex)]
        public string Phone { get; set; }

        [MinLength(1)]
        public BookAuthorImportDto[] Books { get; set; }
    }
}
