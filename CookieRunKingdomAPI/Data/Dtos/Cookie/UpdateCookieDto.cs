using CookieRunKingdomAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace CookieRunKingdomAPI.Data.Dtos.Cookie;

public class UpdateCookieDto
{
    [Required]
    [MaxLength(100, ErrorMessage = "The cookie name cannot exceed 100 characters.")]
    public required string Name { get; set; }

    [Required]
    public required CookieTypes Type { get; set; }

    [Required]
    public required List<CookieElements> Element { get; set; }

    [Required]
    public required List<CookiePositions> Position { get; set; }

    [Required]
    public required CookieRarities Rarity { get; set; }
}