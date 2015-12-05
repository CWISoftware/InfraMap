using InfraMap.Dominio.ModuloRamal;
using InfraMap.Dominio.ModuloRamal.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
