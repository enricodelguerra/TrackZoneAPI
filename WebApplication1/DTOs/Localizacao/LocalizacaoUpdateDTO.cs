// DTOs/Localizacao/LocalizacaoUpdateDTO.cs
namespace WebApplication1.DTOs.Localizacao
{
    public class LocalizacaoUpdateDTO
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string DadosIot { get; set; }
    }
}