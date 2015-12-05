using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloMaquina
{
    public interface IMaquinaRepositorio : IRepositorio<Maquina>
    {
        IList<Maquina> BuscarListaPorNome(string nomeMaquina);

        Maquina BuscarPorNome(string nomeMaquina);
    }
}
