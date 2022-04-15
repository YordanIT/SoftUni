using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseImportDto
    {
        [XmlAttribute("title")]
        public string Title{ get; set; }
        
        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(VaporStoreContextConst.PurchaseProductKeyValidation)]
        [XmlElement("Key")]
        public string ProductKey { get; set; }
        
        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [RegularExpression(VaporStoreContextConst.CardNumberValidation)]     
        [XmlElement("Card")]        
        public string CardNumber { get; set; }
    }
}
