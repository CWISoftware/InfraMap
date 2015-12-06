using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Mesa.Ramal.Queries;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class RamalRepositorio : RepositorioBase<Ramal>, IRamalRepositorio
    {
        public Ramal BuscarRamalPorNumero(string numero)
        {
            return this.Buscar(new BuscarRamalPorNumero(numero)).FirstOrDefault();
        }


        public IList<Ramal> BuscarRamaisPorNumeros(string numero)
        {
            return this.Buscar(new BuscarRamaisPorNumeros(numero));
        }
    }
}
