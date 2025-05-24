using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Localizacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;

        public string DadosIot { get; set; }

        // Relação com Moto
        [Required]
        public int MotoId { get; set; }

        [ForeignKey("MotoId")]
        public Moto Moto { get; set; }
    }
}
