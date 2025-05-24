using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.DTOs.Localizacao;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocalizacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/localizacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalizacaoReadDTO>>> Get()
        {
            var localizacoes = await _context.Localizacoes
                .Include(l => l.Moto)
                .ToListAsync();

            var result = localizacoes.Select(l => new LocalizacaoReadDTO
            {
                Id = l.Id,
                Latitude = l.Latitude,
                Longitude = l.Longitude,
                DataRegistro = l.DataRegistro,
                DadosIot = l.DadosIot,
                MotoId = l.MotoId
            });

            return Ok(result);
        }

        // GET: api/localizacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalizacaoReadDTO>> Get(int id)
        {
            var localizacao = await _context.Localizacoes
                .Include(l => l.Moto)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (localizacao == null) return NotFound();

            var dto = new LocalizacaoReadDTO
            {
                Id = localizacao.Id,
                Latitude = localizacao.Latitude,
                Longitude = localizacao.Longitude,
                DataRegistro = localizacao.DataRegistro,
                DadosIot = localizacao.DadosIot,
                MotoId = localizacao.MotoId
            };

            return Ok(dto);
        }

        // POST: api/localizacoes
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LocalizacaoCreateDTO dto)
        {
            var localizacao = new Localizacao
            {
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                DadosIot = dto.DadosIot,
                DataRegistro = DateTime.UtcNow,
                MotoId = dto.MotoId
            };

            _context.Localizacoes.Add(localizacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = localizacao.Id }, dto);
        }

        // PUT: api/localizacoes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LocalizacaoUpdateDTO dto)
        {
            var localizacao = await _context.Localizacoes.FindAsync(id);
            if (localizacao == null) return NotFound();

            localizacao.Latitude = dto.Latitude;
            localizacao.Longitude = dto.Longitude;
            localizacao.DadosIot = dto.DadosIot;

            _context.Entry(localizacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/localizacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var localizacao = await _context.Localizacoes.FindAsync(id);
            if (localizacao == null) return NotFound();

            _context.Localizacoes.Remove(localizacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
