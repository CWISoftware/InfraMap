using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Mesa.Ramal
{
    public interface IRamalRepositorio : IRepositorio<Ramal>
    {
        IList<Ramal> BuscarRamaisPorNumeros(string numero);

        Dominio.Mesa.Ramal.Ramal BuscarRamalPorNumero(string numero);
    }
}
