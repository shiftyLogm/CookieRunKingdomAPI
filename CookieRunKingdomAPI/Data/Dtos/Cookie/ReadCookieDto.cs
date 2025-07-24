using CookieRunKingdomAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace CookieRunKingdomAPI.Data.Dtos.Cookie;

public class ReadCookieDto
{
    public string Name { get; set; }

    public CookieTypes Type { get; set; }

    public List<CookieElements> Element { get; set; }

    public List<CookiePositions> Position { get; set; }

    public CookieRarities Rarity { get; set; }
}
