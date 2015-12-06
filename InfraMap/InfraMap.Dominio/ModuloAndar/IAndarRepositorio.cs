using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.ModuloMesa;

namespace InfraMap.Dominio.ModuloAndar
{
    public interface IAndarRepositorio 
    {
        Andar BuscarPorId(int id);
    }
}
