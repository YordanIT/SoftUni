using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportDto
    {
        [Required]
        [MinLength(GlobalConst.PrisonerFullNameMinLenght)]
        [MaxLength(GlobalConst.PrisonerFullNameMaxLenght)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(GlobalConst.PrisonerNickNameRegrex)]
        public string Nickname { get; set; }

        [Required]
        [Range(GlobalConst.PrisonerAgeMinValue, GlobalConst.PrisonerAgeMaxValue)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(GlobalConst.PrisonerBailMinValue, (double)decimal.MaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }
        public MailImportDto[] Mails { get; set; }
    }
}
