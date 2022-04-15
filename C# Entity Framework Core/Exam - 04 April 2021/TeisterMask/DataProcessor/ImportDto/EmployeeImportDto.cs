using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeImportDto
    {
        [Required]
        [MinLength(GlobalConst.EmployeeUsernameMinLength)]
        [MaxLength(GlobalConst.EmployeeUsernameMaxLength)]
        [RegularExpression(GlobalConst.EmployeeUsernameRegex)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConst.EmployeePhoneRegex)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
