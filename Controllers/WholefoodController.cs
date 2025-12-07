using Microsoft.AspNetCore.Mvc;
using FoodRecipeApi.Data;
using FoodRecipeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FoodRecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WholefoodController : ControllerBase
    {
        private readonly FoodRecipeContext _context;
        public WholefoodController(FoodRecipeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WholefoodEnDto>>> GetAll()
        {
            return await _context.WholefoodEn.Take(500).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WholefoodEnDto>> GetById(long id)
        {
            var food = await _context.WholefoodEn.FindAsync(id);
            if (food == null) return NotFound();
            return food;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<WholefoodEnDto>> Create(WholefoodEnDto dto)
        {
            _context.WholefoodEn.Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, WholefoodEnDto dto)
        {
            if (id != dto.Id) return BadRequest();
            _context.Entry(dto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.WholefoodEn.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var food = await _context.WholefoodEn.FindAsync(id);
            if (food == null) return NotFound();
            _context.WholefoodEn.Remove(food);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
