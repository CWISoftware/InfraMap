using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloRamal.Queries
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
