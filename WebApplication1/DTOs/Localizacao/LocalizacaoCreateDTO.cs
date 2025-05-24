namespace WebApplication1.DTOs.Localizacao
{
    public class LocalizacaoCreateDTO
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string DadosIot { get; set; }
        public int MotoId { get; set; }
    }
}