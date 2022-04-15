using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastImportDto
    {
        [XmlElement("FullName")]
        [Required]
        [MinLength(GlobalConst.CastFullNameMinLenght)]
        [MaxLength(GlobalConst.CastFullNameMaxLenght)]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        [Required]
        public string IsMainCharacter { get; set; }

        [XmlElement("PhoneNumber")]
        [RegularExpression(GlobalConst.CastPhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}


