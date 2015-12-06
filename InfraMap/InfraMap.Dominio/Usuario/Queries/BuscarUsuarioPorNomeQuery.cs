using System.Linq;
using InfraMap.Comum;

namespace InfraMap.Dominio.Usuario.Queries
{
    public class BuscarUsuarioPorNomeQuery : IQuery<Usuario>
    {
        private readonly string nome;

        public BuscarUsuarioPorNomeQuery(string nome)
        {
            this.nome = nome;
        }

        public IQueryable<Usuario> CriarQuery(IQueryable<Usuario> src)
        {
            return src.Where(t => t.Nome.Equals(this.nome));
        }
    }
}
