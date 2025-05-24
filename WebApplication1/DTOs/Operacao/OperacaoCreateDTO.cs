namespace WebApplication1.DTOs.Operacao
{
    public class OperacaoCreateDTO
    {
        public string TipoOperacao { get; set; }
        public string Observacoes { get; set; }
        public int MotoId { get; set; }
        public int UsuarioId { get; set; }
    }
}