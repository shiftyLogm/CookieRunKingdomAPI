using AutoMapper;
using CookieRunKingdomAPI.Data.Dtos.Cookie;
using CookieRunKingdomAPI.Models;

namespace CookieRunKingdomAPI.Profiles;

public class CookieProfile : Profile
{
    public CookieProfile() 
    {
        CreateMap<CreateCookieDto, Cookie>();
        CreateMap<UpdateCookieDto, Cookie>();
        CreateMap<Cookie, UpdateCookieDto>();
        CreateMap<Cookie, ReadCookieDto>();
    }
}
