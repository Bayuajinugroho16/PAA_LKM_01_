using PAA_LKM_01.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAA_LKM_01.Models
{
    [Table("rentals")]
    public class Rental
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("customer_id")]
        [Required]
        public int CustomerId { get; set; }

        [Column("camera_id")]
        [Required]
        public int CameraId { get; set; }

        [Column("rental_date")]
        [Required]
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;

        [Column("return_date")]
        public DateTime? ReturnDate { get; set; }

        [Column("total_price", TypeName = "decimal(10,2)")]
        public decimal? TotalPrice { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "active";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("CameraId")]
        public virtual Camera Camera { get; set; }
    }
}