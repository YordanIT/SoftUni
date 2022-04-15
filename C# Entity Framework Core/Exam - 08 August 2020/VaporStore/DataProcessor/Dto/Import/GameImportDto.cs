using System;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GameImportDto
	{
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(VaporStoreContextConst.GamePriceMinValue, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

       [Required]
        public string Genre { get; set; }

        [MinLength(1)]
        public string[] Tags { get; set; }
    }
}
