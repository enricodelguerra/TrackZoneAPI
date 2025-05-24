using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class StatusMoto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Area { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Relação com Moto
        [Required]
        public int MotoId { get; set; }

        [ForeignKey("MotoId")]
        public Moto Moto { get; set; }

        // Relação com Usuario
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
