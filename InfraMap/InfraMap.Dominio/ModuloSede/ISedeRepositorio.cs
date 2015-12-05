using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloSede
{
    public interface ISedeRepositorio : IRepositorio<Sede>
    {
        List<Sede> BuscarTodasAsSedes();

        List<Sede> BuscarSedesComAndares();

    }
}
