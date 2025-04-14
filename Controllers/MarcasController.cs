using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocadoraApi.Domain;
using LocadoraApi.Infrastructure.Data; // Adicionei para referenciar a classe Marca

namespace LocadoraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly LocadoraContext _context;

    public MarcasController(LocadoraContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marca>>> GetAllMarcas()
    {
        return await _context.Marcas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marca>> GetMarcaById(int id)
    {
        var marca = await _context.Marcas.FirstOrDefaultAsync(e => e.Codigo == id);
        if (marca == null) 
            return NotFound();
        return Ok(marca);
    }

    [HttpPost]
    public async Task<ActionResult<Marca>> PostMarca(Marca marca)
    {
        _context.Marcas.Add(marca);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetMarcaById), new { id = marca.Codigo }, marca);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMarca(int id, Marca marca)
    {
        if (id != marca.Codigo)
            return BadRequest();
        
        _context.Entry(marca).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Marcas.Any(e => e.Codigo == id))
                return NotFound();
            
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Marca>> DeleteMarca(int id)
    {
        var marca = await _context.Marcas.FindAsync(id);
        if (marca == null)
            return NotFound();
        
        _context.Marcas.Remove(marca);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    
}
