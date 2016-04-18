using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoModeloMaquina : MapeamentoEntidade<ModeloMaquina>
    {
        public MapeamentoModeloMaquina()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(50);
        }
    }
}
