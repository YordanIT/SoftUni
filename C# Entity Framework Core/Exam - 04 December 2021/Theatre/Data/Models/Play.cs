using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConst.PlayTitleMaxlenght)]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        [Range(GlobalConst.PlayRatingMinValue, GlobalConst.PlayRatingMaxValue)]
        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(GlobalConst.PlayDescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConst.PlayScreenwriterMaxLenght)]
        public string Screenwriter { get; set; }

        public ICollection<Cast> Casts { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}


