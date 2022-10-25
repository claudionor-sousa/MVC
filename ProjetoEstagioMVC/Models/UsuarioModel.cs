using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioMVC.Models
{
    public class UsuarioModel
    {
        [Key]
        public long IdUsuario { get; set; }
        [Required(ErrorMessage ="Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido! ")]
        public string Email { get; set; }
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; } 
        public long? IdUsuarioAlteracao { get; set; }

        public bool SenhaValida (string senha)
        {
            return Senha == senha;
        }
    }
}
