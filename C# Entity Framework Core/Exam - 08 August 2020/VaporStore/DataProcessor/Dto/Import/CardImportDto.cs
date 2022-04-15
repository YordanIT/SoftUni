using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardImportDto
    {
        [Required]
        [RegularExpression(VaporStoreContextConst.CardNumberValidation)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(VaporStoreContextConst.CardCvcValidation)]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
