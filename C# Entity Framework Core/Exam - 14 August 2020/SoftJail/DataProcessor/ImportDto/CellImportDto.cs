using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellImportDto
    {
        [Range(GlobalConst.CellNumberMinValue, GlobalConst.CellNumberMaxValue)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}
