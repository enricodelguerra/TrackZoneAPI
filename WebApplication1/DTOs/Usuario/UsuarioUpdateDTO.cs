namespace WebApplication1.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        public string NomeFilial { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Perfil { get; set; }
    }
}
