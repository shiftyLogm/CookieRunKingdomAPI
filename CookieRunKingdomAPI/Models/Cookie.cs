using CookieRunKingdomAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace CookieRunKingdomAPI.Models;

public class Cookie
{
    [Key]
    [Required]
    public Guid id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "The cookie name cannot exceed 100 characters.")]
    public required string name { get; set; }

    [Required]
    public required CookieTypes type { get; set; }

    [Required]
    public required List<CookieElements> element { get; set; }

    [Required]
    public required List<CookiePositions> position { get; set; }

    [Required]
    public required CookieRarities rarity { get; set; }
}
