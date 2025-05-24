using WebApplication1.DTOs.Moto;
using WebApplication1.DTOs.Operacao;
using WebApplication1.DTOs.StatusMoto;

namespace WebApplication1.DTOs
{
    public class UsuarioReadDTO
    {
        public int Id { get; set; }
        public string NomeFilial { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Perfil { get; set; }
        public DateTime DataCriacao { get; set; }

        public List<MotoReadDTO> Motos { get; set; }
        public List<StatusMotoReadDTO> StatusMotos { get; set; }
        public List<OperacaoReadDTO> Operacoes { get; set; }
    }
}
