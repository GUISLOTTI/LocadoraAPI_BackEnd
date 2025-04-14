using System.Data;
using LocadoraApi.Domain;
using LocadoraApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocacoesController : ControllerBase
{
    private readonly LocadoraContext _context;

    public LocacoesController(LocadoraContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Locacao>>> GetAllLocacoes()
    {
        return await _context.Locacoes
            .Include(l => l.IdentificadorCarro)
            .Include(l => l.IdentificadorUsuario)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Locacao>> GetLocacaoById(int id)
    {
        var locacao = await _context.Locacoes
            .Include(l => l.IdentificadorCarro)
            .Include(l => l.IdentificadorUsuario)
            .FirstOrDefaultAsync(l => l.Codigo == id);
        
        if (locacao == null)
            return NotFound();
        return Ok(locacao);
    }

    [HttpPost]
    public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        locacao.DataRetirada = DateTime.SpecifyKind(locacao.DataRetirada, DateTimeKind.Utc);
        locacao.DataDevolucao = DateTime.SpecifyKind(locacao.DataDevolucao, DateTimeKind.Utc);
        
        _context.Locacoes.Add(locacao);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetLocacaoById), new {id = locacao.Codigo}, locacao);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Locacao>> PutLocacao(int id, Locacao locacao)
    {
        if (id != locacao.Codigo)
            return BadRequest(ModelState);
        
        _context.Entry(locacao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Locacoes.Any(e => e.Codigo == id))
                return NotFound();
            
            throw;
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Locacao>> DeleteLocacao(int id)
    {
        var locacao = await _context.Locacoes.FindAsync(id);
        if (locacao == null)
            return NotFound();
        
        _context.Locacoes.Remove(locacao);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}