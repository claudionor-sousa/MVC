using Microsoft.AspNetCore.Mvc;
using ProjetoEstagioMVC.Helper;
using ProjetoEstagioMVC.Models;
using ProjetoEstagioMVC.Repositorio;

namespace ProjetoEstagioMVC.Controllers
{
    public class LoginUsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginUsuarioController(IUsuarioRepositorio usuarioRepositorio,
            ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // se o usuario estiver logado, redirecionar para a home
            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index","Home");
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index","LoginUsuario");
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
                            _sessao.CriarSessaoDoUsuario(usuario);
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
