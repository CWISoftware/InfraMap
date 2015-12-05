using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloRamal
{
    public interface IRamalRepositorio : IRepositorio<Ramal>
    {
        IList<Ramal> BuscarRamaisPorNumeros(string numero);

        Ramal BuscarRamalPorNumero(string numero);
    }
}
