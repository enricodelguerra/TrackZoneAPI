using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.DTOs.StatusMoto;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusMotosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusMotosController(AppDbContext context)
        {
            _context = context;
        }

        private static readonly string[] StatusValidos = new[]
        {
            "PENDENTE", "REPARO_SIMPLES", "DANOS_ESTRUTURAIS", "MOTOR_DEFEITUOSO",
            "MANUTENCAO_AGENDADA", "PRONTA", "SEM_PLACA", "ALUGADA", "AGUARDANDO_ALUGUEL"
        };

        // GET: api/statusmotos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusMotoReadDTO>>> Get()
        {
            var statusList = await _context.StatusMotos
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .ToListAsync();

            var result = statusList.Select(s => new StatusMotoReadDTO
            {
                Id = s.Id,
                Status = s.Status,
                Area = s.Area,
                DataCriacao = s.DataCriacao,
                MotoId = s.MotoId,
                UsuarioId = s.UsuarioId
            });

            return Ok(result);
        }

        // GET: api/statusmotos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusMotoReadDTO>> Get(int id)
        {
            var status = await _context.StatusMotos
                .Include(s => s.Moto)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (status == null) return NotFound();

            var dto = new StatusMotoReadDTO
            {
                Id = status.Id,
                Status = status.Status,
                Area = status.Area,
                DataCriacao = status.DataCriacao,
                MotoId = status.MotoId,
                UsuarioId = status.UsuarioId
            };

            return Ok(dto);
        }

        // POST: api/statusmotos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StatusMotoCreateDTO dto)
        {
            var status = new StatusMoto
            {
                Status = dto.Status,
                Area = dto.Area,
                DataCriacao = DateTime.UtcNow,
                MotoId = dto.MotoId,
                UsuarioId = dto.UsuarioId
            };

            _context.StatusMotos.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = status.Id }, dto);
        }


        // PUT: api/statusmotos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StatusMotoUpdateDTO dto)
        {
            var status = await _context.StatusMotos.FindAsync(id);
            if (status == null) return NotFound();

            if (!StatusValidos.Contains(dto.Status))
                return BadRequest(new { erro = "Status inválido." });

            status.Status = dto.Status;
            status.Area = dto.Area;

            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/statusmotos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _context.StatusMotos.FindAsync(id);
            if (status == null) return NotFound();

            _context.StatusMotos.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
