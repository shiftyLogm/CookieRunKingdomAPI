using CookieRunKingdomAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace CookieRunKingdomAPI.Data.Dtos.Cookie;

public class ReadCookieDto
{
    public required string Name { get; set; }

    public required CookieTypes Type { get; set; }

    public required List<CookieElements> Element { get; set; }

    public required List<CookiePositions> Position { get; set; }

    public required CookieRarities Rarity { get; set; }
}
