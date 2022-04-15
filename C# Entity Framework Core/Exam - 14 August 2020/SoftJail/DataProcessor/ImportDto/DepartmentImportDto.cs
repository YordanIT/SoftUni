using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentImportDto
    {
        [Required]
        [MinLength(GlobalConst.DepartmentNameMinLenght)]
        [MaxLength(GlobalConst.DepartmentNameMaxLenght)]
        public string Name { get; set; }

        [MinLength(1)]
        public CellImportDto[] Cells { get; set; }
    }
}
