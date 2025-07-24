namespace CookieRunKingdomAPI.Data.Dtos;

public class GetResponseDto<T>
{
    public List<T> Rows { get; set; }
    public int Count { get; set; }
    public DateTime GeneratedAt { get; private set; } = DateTime.UtcNow;
}
