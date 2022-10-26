using ProjetoEstagioMVC.Models;

namespace ProjetoEstagioMVC.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
