using Microsoft.AspNetCore.Mvc;
using ProjetoEstagioMVC.Models;
using ProjetoEstagioMVC.Repositorio;

namespace ProjetoEstagioMVC.Controllers
{
    public class LoginUsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginUsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                     UsuarioModel usuario= _usuarioRepositorio.BuscarPorLogin(loginModel.Email);

                    if(usuario !=null)
                    {
                        if (usuario.SenhaValida(loginModel.senha))
                        {
                            return RedirectToAction("Index", "home");
                        }
                        TempData["MensagemErro"] = $"Senha  do usuário é invalida. Por favor, tente novamente";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente";
                }
                return View("index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
