using System.Linq;
using InfraMap.Comum;

namespace InfraMap.Dominio.Mesa.Maquina.Queries
{
    public class BuscarMaquinaPorNomeQuery : IQuery<Maquina>
    {
        private readonly string nome;

        public BuscarMaquinaPorNomeQuery(string nome)
        {
            this.nome = nome;
        }

        public IQueryable<Maquina> CriarQuery(IQueryable<Maquina> src)
        {
            return src.Where(t => t.Nome.Equals(this.nome));
        }
    }
}
