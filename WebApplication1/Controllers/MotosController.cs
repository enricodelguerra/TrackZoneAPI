using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.DTOs.Moto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/motos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoReadDTO>>> Get()
        {
            var motos = await _context.Motos
                .Include(m => m.Usuario)
                .ToListAsync();

            var dtoList = motos.Select(m => new MotoReadDTO
            {
                Id = m.Id,
                Placa = m.Placa,
                Chassi = m.Chassi,
                Motor = m.Motor,
                IotId = m.IotId,
                DataCriacao = m.DataCriacao,
                UsuarioId = m.UsuarioId,
                UsuarioEmail = m.Usuario?.Email
            });

            return Ok(dtoList);
        }


        // GET: api/motos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoReadDTO>> Get(int id)
        {
            var m = await _context.Motos
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (m == null) return NotFound();

            var dto = new MotoReadDTO
            {
                Id = m.Id,
                Placa = m.Placa,
                Chassi = m.Chassi,
                Motor = m.Motor,
                IotId = m.IotId,
                DataCriacao = m.DataCriacao,
                UsuarioId = m.UsuarioId,
                UsuarioEmail = m.Usuario?.Email
            };

            return dto;
        }


        // POST: api/motos
        [HttpPost]
        public async Task<ActionResult> Post(MotoCreateDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.UsuarioId);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            var moto = new Moto
            {
                Placa = dto.Placa,
                Chassi = dto.Chassi,
                Motor = dto.Motor,
                IotId = dto.IotId,
                UsuarioId = dto.UsuarioId,
                DataCriacao = DateTime.UtcNow
            };

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = moto.Id }, moto);
        }


        // PUT: api/motos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, MotoUpdateDTO dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            moto.Placa = dto.Placa;
            moto.Chassi = dto.Chassi;
            moto.Motor = dto.Motor;
            moto.IotId = dto.IotId;
            moto.UsuarioId = dto.UsuarioId;

            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/motos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
