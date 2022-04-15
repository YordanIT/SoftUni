using SoftJail.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerImportDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConst.OfficerFullNameMinLenght)]
        [MaxLength(GlobalConst.OfficerFullNameMaxLenght)]
        public string FullName { get; set; }

        [XmlElement("Money")]
        [Range(GlobalConst.OfficerSalaryMinValue, (double)decimal.MaxValue)]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray]
        public OfficerPrisonerImportDto[] Prisoners { get; set; }
    }
}


