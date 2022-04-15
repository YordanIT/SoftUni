using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketImportDto
    {
        [Range(GlobalConst.TicketPriceMinValue, GlobalConst.TicketPriceMaxValue)]
        public decimal Price { get; set; }

        [Range(GlobalConst.TicketRowNumberMinValue, GlobalConst.TicketRowNumberMaxValue)]
        public int RowNumber { get; set; }

        public int PlayId { get; set; }
    }
}
