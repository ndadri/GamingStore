// GamingStore.API/Controllers/TecladoController.cs
using GamingStore.API.Data;
using GamingStore.API.Models;
using GamingStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TecladoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TecladoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Teclado
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teclado>>> GetTeclados()
    {
        return await _context.Teclados.ToListAsync();
    }

    // GET: api/Teclado/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Teclado>> GetTeclado(int id)
    {
        var teclado = await _context.Teclados.FindAsync(id);

        if (teclado == null)
        {
            return NotFound();
        }

        return teclado;
    }

    // POST: api/Teclado
    [HttpPost]
    public async Task<ActionResult<Teclado>> PostTeclado(Teclado teclado)
    {
        _context.Teclados.Add(teclado);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTeclado), new { id = teclado.Id }, teclado);
    }
}
