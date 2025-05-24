namespace WebApplication1.DTOs.Operacao
{
    public class OperacaoReadDTO
    {
        public int Id { get; set; }
        public string TipoOperacao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioEmail { get; set; }
        public int MotoId { get; set; }
        public int UsuarioId { get; set; }
    }
}