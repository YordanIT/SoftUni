using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheatreImportDto
    {
        [Required]
        [MinLength(GlobalConst.TheatreNameMinLenght)]
        [MaxLength(GlobalConst.TheatreNameMaxLenght)]
        public string Name { get; set; }

        [Range(GlobalConst.TheatreNumberOfHallsMinValue,
            GlobalConst.TheatreNumberOfHallsMaxValue)]
        public int NumberOfHalls { get; set; }

        [Required]
        [MinLength(GlobalConst.TheatreDirectorMinLenght)]
        [MaxLength(GlobalConst.TheatreDirectorMaxLenght)]
        public string Director { get; set; }

        public TicketImportDto[] Tickets { get; set; }
    }
}

