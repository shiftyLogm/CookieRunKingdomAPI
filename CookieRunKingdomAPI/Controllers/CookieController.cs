using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieRunKingdomAPI.Models;
using CookieRunKingdomAPI.Data.Contexts;
using AutoMapper;
using CookieRunKingdomAPI.Data.Dtos.Cookie;
using Microsoft.AspNetCore.JsonPatch;
using CookieRunKingdomAPI.Data.Dtos;

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
    public async Task<ActionResult<IEnumerable<ReadCookieDto>>> GetCookies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var count = await _context.Cookies.CountAsync();
        var cookies = await _context.Cookies.Skip(skip).Take(take).ToListAsync();
        var cookiesDto = _mapper.Map<List<ReadCookieDto>>(cookies);

        var response = new GetResponseDto<ReadCookieDto>
        {
            Rows = cookiesDto,
            Count = count
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadCookieDto>> GetCookie(Guid id)
    {
        var cookie = await _context.Cookies.FindAsync(id);

        if (cookie == null) return NotFound();

        var cookieDto = _mapper.Map<ReadCookieDto>(cookie);

        return Ok(cookieDto);
    }

    [HttpPost]
    public async Task<ActionResult<Cookie>> PostCookie([FromBody] CreateCookieDto cookieDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Cookie cookie = _mapper.Map<Cookie>(cookieDto);
        _context.Cookies.Add(cookie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCookie), new { cookie.Id }, cookie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCookie(Guid id, [FromBody] UpdateCookieDto cookieDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var cookie = await _context.Cookies.FindAsync(id);

        if (cookie == null) return NotFound();

        _mapper.Map(cookieDto, cookie);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchCookie(Guid id, JsonPatchDocument<UpdateCookieDto> patchObj)
    {
        var cookie = await _context.Cookies.FindAsync(id);

        if (cookie == null) return NotFound();

        var newCookie = _mapper.Map<UpdateCookieDto>(cookie);

        patchObj.ApplyTo(newCookie, ModelState);

        if (!TryValidateModel(newCookie)) return ValidationProblem();

        _mapper.Map(newCookie, cookie);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCookie(Guid id) 
    {
        var cookie = await _context.Cookies.FindAsync(id);

        if (cookie == null) return NotFound();

        _context.Cookies.Remove(cookie);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
