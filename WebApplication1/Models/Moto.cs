using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Moto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Chassi { get; set; }

        public string Motor { get; set; }

        public string IotId { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        // Relacionamentos para tabelas relacionadas
        public ICollection<StatusMoto> StatusMotos { get; set; }
        public ICollection<Operacao> Operacoes { get; set; }
        public ICollection<Localizacao> Localizacoes { get; set; }
    }
}
