using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloColaborador
{
    public interface IColaboradorRepositorio : IRepositorio<Colaborador>
    {
        IList<Colaborador> BuscarPorNome(string nome);
    }
}
