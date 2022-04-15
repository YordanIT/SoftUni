using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayImportDto
    {
        [XmlElement("Title")]
        [Required]
        [MinLength(GlobalConst.PlayTitleMinlenght)]
        [MaxLength(GlobalConst.PlayTitleMaxlenght)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(GlobalConst.PlayRatingMinValue, GlobalConst.PlayRatingMaxValue)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [MaxLength(GlobalConst.PlayDescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        [MinLength(GlobalConst.PlayScreenwriterMinLenght)]
        [MaxLength(GlobalConst.PlayScreenwriterMaxLenght)]
        public string Screenwriter { get; set; }
    }
}

