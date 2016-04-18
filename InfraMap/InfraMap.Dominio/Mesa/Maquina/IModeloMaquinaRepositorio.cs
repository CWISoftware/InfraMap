using InfraMap.Dominio.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public interface IModeloMaquinaRepositorio : IRepositorio<ModeloMaquina>
    {
        List<ModeloMaquina> BuscarTodos();
    }
}
