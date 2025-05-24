namespace WebApplication1.DTOs.StatusMoto
{
    public class StatusMotoCreateDTO
    {
        public string Status { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int MotoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
