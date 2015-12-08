using System.Linq;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Usuario.Queries
{
    public class BuscarUsuariosPorNomeQuery : IQuery<Usuario>
    {
        private readonly string nome;

        public BuscarUsuariosPorNomeQuery(string nome)
        {
            this.nome = nome;        
        }

        public IQueryable<Usuario> CriarQuery(IQueryable<Usuario> src)
        {
            return src.Where(t => t.Nome.StartsWith(this.nome));
        }
    }
}
