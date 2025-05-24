using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.DTOs.Operacao;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OperacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/operacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperacaoReadDTO>>> Get()
        {
            var operacoes = await _context.Operacoes
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .ToListAsync();

            var result = operacoes.Select(o => new OperacaoReadDTO
            {
                Id = o.Id,
                TipoOperacao = o.TipoOperacao,
                Observacoes = o.Observacoes,
                DataCriacao = o.DataCriacao,
                MotoId = o.MotoId,
                UsuarioId = o.UsuarioId,
                UsuarioEmail = o.Usuario?.Email
            });

            return Ok(result);
        }

        // GET: api/operacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacaoReadDTO>> Get(int id)
        {
            var operacao = await _context.Operacoes
                .Include(o => o.Moto)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (operacao == null)
                return NotFound();

            var dto = new OperacaoReadDTO
            {
                Id = operacao.Id,
                TipoOperacao = operacao.TipoOperacao,
                Observacoes = operacao.Observacoes,
                DataCriacao = operacao.DataCriacao,
                MotoId = operacao.MotoId,
                UsuarioId = operacao.UsuarioId,
                UsuarioEmail = operacao.Usuario?.Email
            };

            return Ok(dto);
        }

        // POST: api/operacoes
        [HttpPost]
        public async Task<ActionResult> Post(OperacaoCreateDTO dto)
        {
            var operacao = new Operacao
            {
                TipoOperacao = dto.TipoOperacao,
                Observacoes = dto.Observacoes,
                DataCriacao = DateTime.Now,
                MotoId = dto.MotoId,
                UsuarioId = dto.UsuarioId
            };

            _context.Operacoes.Add(operacao);
            await _context.SaveChangesAsync();

            var usuario = await _context.Usuarios.FindAsync(dto.UsuarioId);

            var readDto = new OperacaoReadDTO
            {
                Id = operacao.Id,
                TipoOperacao = operacao.TipoOperacao,
                Observacoes = operacao.Observacoes,
                DataCriacao = operacao.DataCriacao,
                MotoId = operacao.MotoId,
                UsuarioId = operacao.UsuarioId,
                UsuarioEmail = usuario?.Email
            };

            return CreatedAtAction(nameof(Get), new { id = operacao.Id }, readDto);
        }

        // PUT: api/operacoes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, OperacaoUpdateDTO dto)
        {
            var operacao = await _context.Operacoes.FindAsync(id);
            if (operacao == null)
                return NotFound();

            operacao.TipoOperacao = dto.TipoOperacao;
            operacao.Observacoes = dto.Observacoes;
            operacao.MotoId = dto.MotoId;
            operacao.UsuarioId = dto.UsuarioId;

            _context.Entry(operacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/operacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var operacao = await _context.Operacoes.FindAsync(id);
            if (operacao == null)
                return NotFound();

            _context.Operacoes.Remove(operacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}