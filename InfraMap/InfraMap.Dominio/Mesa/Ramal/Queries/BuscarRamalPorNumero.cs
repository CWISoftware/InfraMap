using System.Linq;
using InfraMap.Comum;

namespace InfraMap.Dominio.Mesa.Ramal.Queries
{
    public class BuscarRamalPorNumero : IQuery<Ramal>
    {
        private readonly string numero;

        public BuscarRamalPorNumero(string numero)
        {
            this.numero = numero;
        }

        public IQueryable<Ramal> CriarQuery(IQueryable<Ramal> src)
        {
            return src.Where(t => t.Numero.Equals(this.numero));
        }
    }
}
