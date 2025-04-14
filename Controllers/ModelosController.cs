using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocadoraApi.Domain;
using LocadoraApi.Infrastructure.Data;

namespace LocadoraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelosController : ControllerBase
{
    private readonly LocadoraContext _context;

    public ModelosController(LocadoraContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Modelo>>> GetAllModelos()
    {
        return await _context.Modelos.Include(m => m.ReferenciaMarca).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Modelo>> GetModeloById(int id)
    {
        var modelo = await _context.Modelos.Include(m => m.ReferenciaMarca).FirstOrDefaultAsync(m => m.Codigo == id);
        if (modelo == null)
            return NotFound();
        return Ok(modelo);
    }

    [HttpPost]
    public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
    {
        _context.Modelos.Add(modelo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetModeloById), new { id = modelo.Codigo }, modelo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutModelo(int id, Modelo modelo)
    {
        if (id != modelo.Codigo)
            return BadRequest(ModelState);

        _context.Entry(modelo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Modelos.Any(e => e.Codigo == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModelo(int id)
    {
        var modelo = await _context.Modelos.FindAsync(id);
        if (modelo == null)
            return NotFound();

        _context.Modelos.Remove(modelo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}