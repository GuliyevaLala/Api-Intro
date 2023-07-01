using Api___intro.Data;
using Api___intro.Models;
using Api___intro.DTOs.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_Intro.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country country = new();

            country.Name = request.Name;
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return Ok();
        }




        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDTO request)
        {
            Country? country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (country == null) return NotFound();

            country.Name = request.Name;

            _context.Countries.Update(country);
            await _context.SaveChangesAsync();

            return Ok(country);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (country == null) return NotFound();
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpGet]
        [Route("{searchText}")]
        public async Task<IActionResult> GetBySearchText([FromRoute] string searchText)
        {
            var countries = await _context.Countries.Where(m => m.Name.Contains(searchText)).ToListAsync();
            return Ok(countries);
        }

       
    }
}
