using GamingStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingStore.API.Controllers
{
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
        // Obtiene todos los teclados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teclado>>> GetTeclados()
        {
            return await _context.Teclados.ToListAsync();
        }

        // GET: api/Teclado/5
        // Obtiene un teclado por su ID
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
        // Crea un nuevo teclado
        [HttpPost]
        public async Task<ActionResult<Teclado>> PostTeclado(Teclado teclado)
        {
            _context.Teclados.Add(teclado);
            await _context.SaveChangesAsync();

            // Retorna el teclado creado y su ubicación (URI) en la API
            return CreatedAtAction(nameof(GetTeclado), new { id = teclado.Id }, teclado);
        }

        // PUT: api/Teclado/5
        // Actualiza un teclado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeclado(int id, Teclado teclado)
        {
            if (id != teclado.Id)
            {
                return BadRequest();
            }

            _context.Entry(teclado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();  // Retorna un código de estado 204 si todo salió bien
        }

        // DELETE: api/Teclado/5
        // Elimina un teclado por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeclado(int id)
        {
            var teclado = await _context.Teclados.FindAsync(id);
            if (teclado == null)
            {
                return NotFound();
            }

            _context.Teclados.Remove(teclado);
            await _context.SaveChangesAsync();

            return NoContent();  // Retorna un código de estado 204 si la eliminación fue exitosa
        }
    }
}
