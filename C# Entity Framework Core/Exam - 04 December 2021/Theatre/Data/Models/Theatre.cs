using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConst.TheatreNameMaxLenght)]
        public string Name { get; set; }

        [Range(GlobalConst.TheatreNumberOfHallsMinValue, 
            GlobalConst.TheatreNumberOfHallsMaxValue)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(GlobalConst.TheatreDirectorMaxLenght)]
        public string Director { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}


