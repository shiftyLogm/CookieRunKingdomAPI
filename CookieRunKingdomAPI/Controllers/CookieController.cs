using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieRunKingdomAPI.Models;
using CookieRunKingdomAPI.Data.Contexts;
using CookieRunKingdomAPI.Data.Dtos;
using AutoMapper;

namespace CookieRunKingdomAPI.Controllers;

[Route("/cookies")]
[ApiController]
public class CookiesController : ControllerBase
{
    private readonly CookieContext _context;
    private IMapper _mapper;

    public CookiesController(CookieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cookie>>> GetCookies()
    {
        return await _context.Cookies.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cookie>> GetCookie(Guid id)
    {
        var cookie = await _context.Cookies.FindAsync(id);

        if (cookie == null)
        {
            return NotFound();
        }

        return Ok(cookie);
    }

    [HttpPost]
    public async Task<ActionResult<Cookie>> PostCookie([FromBody] CookieDto cookieDto)
    {
        Cookie cookie = _mapper.Map<Cookie>(cookieDto);
        _context.Cookies.Add(cookie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCookie), new { cookie.id }, cookie);
    }
}
