using CookieRunKingdomAPI.Enums;
using CookieRunKingdomAPI.Resources;
using System.ComponentModel.DataAnnotations;

namespace CookieRunKingdomAPI.Data.Dtos.Cookie;

public class CreateCookieDto
{
    [Required]
    [StringLength(100, ErrorMessageResourceName = "CookieNameMaxLengthError", ErrorMessageResourceType = typeof(MessageService))]
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