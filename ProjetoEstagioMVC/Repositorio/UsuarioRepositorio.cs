using ProjetoEstagioMVC.data;
using ProjetoEstagioMVC.Models;

namespace ProjetoEstagioMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancocontext)
        {
            _bancoContext = bancocontext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Email.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(long id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }

        public UsuarioModel Adicionar(UsuarioModel Usuario)
        {

            _bancoContext.Usuario.Add(Usuario);
            _bancoContext.SaveChanges();
            return Usuario;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();
        }

        public UsuarioModel Atualizar(UsuarioModel Usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(Usuario.IdUsuario);
            if (usuarioDB == null) throw new Exception("houve um erro na atualização do contato! ");
            usuarioDB.Nome = Usuario.Nome;
            usuarioDB.Email = Usuario.Email;
            usuarioDB.DataAlteracao = DateTime.Now;
            usuarioDB.Senha = Usuario.Senha;
            usuarioDB.DataCadastro = Usuario.DataCadastro;

            _bancoContext.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;
        }

        public bool Apagar(long id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new Exception("Houve um erro ao deletar o usuário! ");
            _bancoContext.Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;

        }

    } 
}
