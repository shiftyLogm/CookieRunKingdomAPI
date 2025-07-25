using CookieRunKingdomAPI.Enums;
using System.ComponentModel.DataAnnotations;
using CookieRunKingdomAPI.Resources;

namespace CookieRunKingdomAPI.Models;

public class Cookie
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
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
