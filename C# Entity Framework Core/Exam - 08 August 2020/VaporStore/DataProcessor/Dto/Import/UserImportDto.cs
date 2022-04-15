using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportDto
    {
        [Required]
        [MinLength(VaporStoreContextConst.UserNameMinLenght)]
        [MaxLength(VaporStoreContextConst.UserNameMaxLenght)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(VaporStoreContextConst.UserFullNameValitadion)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(VaporStoreContextConst.UserMinAge, VaporStoreContextConst.UserMaxAge)]
        public int Age { get; set; }

        public CardImportDto[] Cards { get; set; }
    }
}
