using System.Linq;
using InfraMap.Comum;

namespace InfraMap.Dominio.Mesa.Ramal.Queries
{
    public class BuscarRamaisPorNumeros : IQuery<Ramal>
    {
        private readonly string numero;

        public BuscarRamaisPorNumeros(string numero)
        {
            this.numero = numero;
        }

        public IQueryable<Ramal> CriarQuery(IQueryable<Ramal> src)
        {
            return src.Where(t => t.Numero.StartsWith(this.numero));
        }
    }
}
