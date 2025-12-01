using Microsoft.AspNetCore.Mvc;
using FoodRecipeApi.Data;
using FoodRecipeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FoodRecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly FoodRecipeContext _context;
        public RecipesController(FoodRecipeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipesEnDto>>> GetAll()
        {
            return await _context.RecipesEn.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipesEnDto>> GetById(long id)
        {
            var recipe = await _context.RecipesEn.FindAsync(id);
            if (recipe == null) return NotFound();
            return recipe;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RecipesEnDto>> Create(RecipesEnDto dto)
        {
            _context.RecipesEn.Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, RecipesEnDto dto)
        {
            if (id != dto.Id) return BadRequest();
            _context.Entry(dto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RecipesEn.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var recipe = await _context.RecipesEn.FindAsync(id);
            if (recipe == null) return NotFound();
            _context.RecipesEn.Remove(recipe);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
