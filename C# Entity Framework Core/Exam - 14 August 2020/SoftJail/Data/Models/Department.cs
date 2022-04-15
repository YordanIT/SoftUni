using SoftJail.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConst.DepartmentNameMaxLenght)]
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; }
    }
}

