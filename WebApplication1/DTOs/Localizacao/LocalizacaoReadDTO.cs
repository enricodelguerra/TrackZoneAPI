namespace WebApplication1.DTOs.Localizacao
{
    public class LocalizacaoReadDTO
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DataRegistro { get; set; }
        public string DadosIot { get; set; }
        public int MotoId { get; set; }
    }
}