using System.ComponentModel.DataAnnotations;

public class CameraUpdateDto
{
    [MaxLength(50)]
    public string Brand { get; set; } = string.Empty;  // default value

    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    [Range(1, 10000000)]
    public decimal? PricePerDay { get; set; }  // decimal? tetap boleh

    [Range(0, 1000)]
    public int? Stock { get; set; }
}