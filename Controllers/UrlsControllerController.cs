using Microsoft.AspNetCore.Mvc;
using UrlShortenerApi.Data;
using UrlShortenerApi.Models;
using System.Linq;

namespace UrlShortenerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlsController : ControllerBase
    {
        private readonly UrlDbContext _context;

        public UrlsController(UrlDbContext context)
        {
            _context = context;
        }

        [HttpPost("shorten")]
        public IActionResult ShortenUrl([FromBody] string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
                // return BadRequest("Invalid URL.");
                return BadRequest(new { error = "Invalid URL." });

            var shortUrl = GenerateShortUrl();
            var urlMapping = new UrlMapping { LongUrl = longUrl, ShortUrl = shortUrl };

            _context.UrlMappings.Add(urlMapping);
            _context.SaveChanges();

            // return Ok(shortUrl);
            return Ok(new { shortUrl });
        }

        [HttpGet("{shortUrl}")]
        public IActionResult RedirectToLongUrl(string shortUrl)
        {
            var mapping = _context.UrlMappings.FirstOrDefault(x => x.ShortUrl == shortUrl);

            if (mapping == null)
                return NotFound("Short URL not found.");

            return Redirect(mapping.LongUrl);
        }

        private string GenerateShortUrl()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
