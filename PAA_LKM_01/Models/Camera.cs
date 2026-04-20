using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAA_LKM_01.Models
{
    [Table("cameras")]
    public class Camera
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("brand")]
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Column("model")]
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Column("price_per_day", TypeName = "decimal(10,2)")]
        [Required]
        public decimal PricePerDay { get; set; }

        [Column("stock")]
        [Required]
        public int Stock { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}