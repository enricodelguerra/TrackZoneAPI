using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeFilial { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        [Required]
        public string Cnpj { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        [Required]
        public string Perfil { get; set; }

        public DateTime DataCriacao { get; set; }

        public ICollection<Moto> Motos { get; set; }
        public ICollection<StatusMoto> StatusMotos { get; set; }
        public ICollection<Operacao> Operacoes { get; set; }
    }
}
