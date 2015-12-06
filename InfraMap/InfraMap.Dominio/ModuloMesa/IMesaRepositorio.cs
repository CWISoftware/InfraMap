using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloMesa
{
    public interface IMesaRepositorio
    {
        Mesa BuscarPorId(int id);

        void Adicionar(Mesa entity);

        void Atualizar(Mesa entity);

        IList<Mesa> Buscar();
    }
}
