namespace WebApplication1.DTOs.Moto
{
    public class MotoReadDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Motor { get; set; }
        public string IotId { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioEmail { get; set; } // Exemplo para mostrar info do dono
    }
}
