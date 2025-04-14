using System.Net.Sockets;
using LocadoraApi.Domain;
using LocadoraApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrosController : ControllerBase
{
    private readonly LocadoraContext _context;

    public CarrosController(LocadoraContext context)
    {
        _context = context;
    }

//GET (sempre referenciando o modelo utilizando o .Include) **VÁLIDO APENAS PARA MÉTODOS GET QUANDO HÁ REFERENCIA**
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carro>>> GetAllCarros()
    {
        return await _context.Carros.Include(c => c.ReferenciaModelo).ToListAsync();
    }

//GET_BY_ID (sempre referenciando o modelo utilizando o .Include) **VÁLIDO APENAS PARA MÉTODOS GET QUANDO HÁ REFERENCIA**
    [HttpGet("{id}")]
    public async Task<ActionResult<Carro>> GetCarroById(int id)
    {
        var carro = await _context.Carros.Include(c => c.ReferenciaModelo).FirstOrDefaultAsync(C => C.Codigo == id);
        if (carro == null)
            return NotFound();
        return Ok (carro);
    }
//POST (primeiro instancia o guid para depois poder adicionar o carro e depois retornar-lo utilizando nameof(GetCarro)) 
[HttpPost]
    public async Task<ActionResult<Carro>> PostCarro(Carro carro)
    {
        carro.IdentificadorCarro = Guid.NewGuid();
        
        _context.Carros.Add(carro);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetCarroById), new { id = carro.Codigo}, carro);
    }

// PUT (PESQUIsAR O PORQUE USAR .Entry E TAMBÉM SOBRE EntityState.Modified && .Any)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCarro(int id, Carro carro)
    {
        if (id != carro.Codigo)
            return BadRequest(ModelState);
        
        _context.Entry(carro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Carros.Any(e => e.Codigo == id))
                return NotFound();

            throw;
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarro(int id)
    {
        var carro = await _context.Carros.FindAsync(id);
        if (carro == null)
            return NotFound();
        
        _context.Carros.Remove(carro);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}