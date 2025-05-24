// DTOs/StatusMoto/StatusMotoReadDTO.cs
namespace WebApplication1.DTOs.StatusMoto
{
    public class StatusMotoReadDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public DateTime DataCriacao { get; set; }
        public int MotoId { get; set; }
        public int UsuarioId { get; set; }
    }
}