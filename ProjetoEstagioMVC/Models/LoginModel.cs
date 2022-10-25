using System.ComponentModel.DataAnnotations;

namespace ProjetoEstagioMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string senha { get; set; }
    }
}
