using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public interface IMaquinaRepositorio : IRepositorio<Maquina>
    {
        IList<Maquina> BuscarListaPorNome(string nomeMaquina);

        Maquina BuscarPorNome(string nomeMaquina);
    }
}
