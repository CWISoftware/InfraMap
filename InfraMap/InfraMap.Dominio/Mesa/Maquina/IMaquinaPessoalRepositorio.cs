using InfraMap.Dominio.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public interface IMaquinaPessoalRepositorio : IRepositorio<MaquinaPessoal>
    {
        int BuscarPorEtiquetaServico(MaquinaPessoal maquina);
        int BuscarPorPatrimonio(MaquinaPessoal maquina);
        MaquinaPessoal BuscarPorPatrimonio2(int patrimonio);
    }
}
