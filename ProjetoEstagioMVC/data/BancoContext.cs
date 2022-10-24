using Microsoft.EntityFrameworkCore;
using ProjetoEstagioMVC.Models;

namespace ProjetoEstagioMVC.data
{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        
        
    }
}
