using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloAndar
{
    public interface IAndarRepositorio : IRepositorio<Andar>
    {
        List<Andar> BuscarAndaresPorSede(int idSede);

    }
}
