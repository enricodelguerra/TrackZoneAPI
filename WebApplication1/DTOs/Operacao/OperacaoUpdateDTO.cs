namespace WebApplication1.DTOs.Operacao
{
    public class OperacaoUpdateDTO
    {
        public string TipoOperacao { get; set; }
        public string Observacoes { get; set; }
        public int MotoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
