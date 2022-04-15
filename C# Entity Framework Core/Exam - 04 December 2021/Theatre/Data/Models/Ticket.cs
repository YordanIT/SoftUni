using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(GlobalConst.TicketPriceMinValue, GlobalConst.TicketPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(GlobalConst.TicketRowNumberMinValue, GlobalConst.TicketRowNumberMaxValue)]
        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public Play Play { get; set; }

        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}

