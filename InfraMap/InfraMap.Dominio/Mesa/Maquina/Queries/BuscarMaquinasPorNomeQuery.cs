using System.Linq;
using InfraMap.Comum;

namespace InfraMap.Dominio.Mesa.Maquina.Queries
{
    public class BuscarMaquinasPorNomeQuery : IQuery<Maquina>
    {
        private readonly string nomeMaquina;

        public BuscarMaquinasPorNomeQuery(string nomeMaquina)
        {
            this.nomeMaquina = nomeMaquina;
        }

        public IQueryable<Maquina> CriarQuery(IQueryable<Maquina> src)
        {
            return src.Where(t => t.Nome.StartsWith(this.nomeMaquina));
        }
    }
}
