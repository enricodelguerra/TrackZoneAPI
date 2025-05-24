using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.DTOs.Moto;
using WebApplication1.DTOs.Operacao;
using WebApplication1.DTOs.StatusMoto;
using WebApplication1.DTOs.Usuario;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Motos)
                .Include(u => u.StatusMotos)
                .Include(u => u.Operacoes)
                .ToListAsync();

            var usuariosDto = usuarios.Select(usuario => new UsuarioReadDTO
            {
                Id = usuario.Id,
                NomeFilial = usuario.NomeFilial,
                Email = usuario.Email,
                Cnpj = usuario.Cnpj,
                Endereco = usuario.Endereco,
                Telefone = usuario.Telefone,
                Perfil = usuario.Perfil,
                DataCriacao = usuario.DataCriacao,

                Motos = usuario.Motos?.Select(m => new MotoReadDTO
                {
                    Id = m.Id,
                    Placa = m.Placa,
                    Chassi = m.Chassi,
                    Motor = m.Motor,
                    IotId = m.IotId,
                    DataCriacao = m.DataCriacao,
                    UsuarioId = m.UsuarioId,
                    UsuarioEmail = usuario.Email
                }).ToList(),

                StatusMotos = usuario.StatusMotos?.Select(s => new StatusMotoReadDTO
                {
                    Id = s.Id,
                    Status = s.Status,
                    Area = s.Area,
                    DataCriacao = s.DataCriacao,
                    MotoId = s.MotoId,
                    UsuarioId = s.UsuarioId
                }).ToList(),

                Operacoes = usuario.Operacoes?.Select(o => new OperacaoReadDTO
                {
                    Id = o.Id,
                    TipoOperacao = o.TipoOperacao,
                    Observacoes = o.Observacoes,
                    DataCriacao = o.DataCriacao,
                    MotoId = o.MotoId,
                    UsuarioId = o.UsuarioId,
                    UsuarioEmail = usuario.Email
                }).ToList()
            }).ToList();

            return usuariosDto;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Motos)
                .Include(u => u.StatusMotos)
                .Include(u => u.Operacoes)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null) return NotFound();

            var dto = new UsuarioReadDTO
            {
                Id = usuario.Id,
                NomeFilial = usuario.NomeFilial,
                Email = usuario.Email,
                Cnpj = usuario.Cnpj,
                Endereco = usuario.Endereco,
                Telefone = usuario.Telefone,
                Perfil = usuario.Perfil,
                DataCriacao = usuario.DataCriacao,

                Motos = usuario.Motos?.Select(m => new MotoReadDTO
                {
                    Id = m.Id,
                    Placa = m.Placa,
                    Chassi = m.Chassi,
                    Motor = m.Motor,
                    IotId = m.IotId,
                    DataCriacao = m.DataCriacao,
                    UsuarioId = m.UsuarioId,
                    UsuarioEmail = usuario.Email
                }).ToList(),

                StatusMotos = usuario.StatusMotos?.Select(s => new StatusMotoReadDTO
                {
                    Id = s.Id,
                    Status = s.Status,
                    Area = s.Area,
                    DataCriacao = s.DataCriacao,
                    MotoId = s.MotoId,
                    UsuarioId = s.UsuarioId
                }).ToList(),

                Operacoes = usuario.Operacoes?.Select(o => new OperacaoReadDTO
                {
                    Id = o.Id,
                    TipoOperacao = o.TipoOperacao,
                    Observacoes = o.Observacoes,
                    DataCriacao = o.DataCriacao,
                    MotoId = o.MotoId,
                    UsuarioId = o.UsuarioId,
                    UsuarioEmail = usuario.Email
                }).ToList()
            };

            return dto;
        }



        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                NomeFilial = dto.NomeFilial,
                Email = dto.Email,
                SenhaHash = dto.SenhaHash,
                Cnpj = dto.Cnpj,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Perfil = dto.Perfil,
                DataCriacao = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            usuario.NomeFilial = dto.NomeFilial;
            usuario.Email = dto.Email;
            usuario.SenhaHash = dto.SenhaHash;
            usuario.Cnpj = dto.Cnpj;
            usuario.Endereco = dto.Endereco;
            usuario.Telefone = dto.Telefone;
            usuario.Perfil = dto.Perfil;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }


        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
    }
}
