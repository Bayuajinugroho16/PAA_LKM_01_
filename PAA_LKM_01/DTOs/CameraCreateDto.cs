using System.ComponentModel.DataAnnotations;

namespace PAA_LKM_01.DTOs
{
    public class CameraCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [Range(1, 10000000)]
        public decimal PricePerDay { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Stock { get; set; }
    }

    public class CameraUpdateDto
    {
        [MaxLength(50)]
        public string Brand { get; set; }

        [MaxLength(100)]
        public string Model { get; set; }

        [Range(1, 10000000)]
        public decimal? PricePerDay { get; set; }

        [Range(0, 1000)]
        public int? Stock { get; set; }
    }
}