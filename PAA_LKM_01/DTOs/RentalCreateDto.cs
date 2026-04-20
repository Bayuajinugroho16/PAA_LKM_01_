using System.ComponentModel.DataAnnotations;

namespace PAA_LKM_01.DTOs
{
    public class RentalCreateDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int CameraId { get; set; }

        [Required]
        [Range(1, 30)]
        public int Days { get; set; }
    }
}