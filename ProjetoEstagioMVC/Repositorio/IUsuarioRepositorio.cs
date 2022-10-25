using ProjetoEstagioMVC.Models;

namespace ProjetoEstagioMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(long id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel Usuario);
        UsuarioModel Atualizar(UsuarioModel Usuario);

        bool Apagar(long id);
    }
}
