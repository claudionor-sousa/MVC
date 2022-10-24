using Microsoft.AspNetCore.Mvc;
using ProjetoEstagioMVC.Models;
using ProjetoEstagioMVC.Repositorio;

namespace ProjetoEstagioMVC.Controllers
{
    public class UsuarioDoSistemaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioDoSistemaController(IUsuarioRepositorio usuariorepositorio)
        {
            _usuarioRepositorio = usuariorepositorio;

        }
        public IActionResult Index()
        {
           List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            UsuarioModelConjut usuarioModelConjut = new UsuarioModelConjut();
            usuarioModelConjut.ListUsuario = usuarios;
            return View(usuarioModelConjut);
        }
        public IActionResult Editar(long id) 
        {
             UsuarioModel usuario= _usuarioRepositorio.ListarPorId(id);
            return PartialView("Editar",usuario);
        }
        public IActionResult Delete(long id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return  PartialView("Delete",usuario);
        }
        public IActionResult Apagar(long id)
        {
            
            try
            {
                bool apagado=_usuarioRepositorio.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar seu usuário!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar seu usuário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel Usuario)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(Usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastro com sucesso";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel Usuario)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(Usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", Usuario);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos Alterar seu usuário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
