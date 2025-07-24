using AutoMapper;
using CookieRunKingdomAPI.Data.Dtos;
using CookieRunKingdomAPI.Models;

namespace CookieRunKingdomAPI.Profiles;

public class CookieProfile : Profile
{
    public CookieProfile() 
    {
        CreateMap<CookieDto, Cookie>();
    }
}
