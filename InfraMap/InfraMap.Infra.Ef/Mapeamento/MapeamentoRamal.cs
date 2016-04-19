using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Ramal;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoRamal : MapeamentoEntidade<Ramal>
    {
        public MapeamentoRamal()
        {
            Property(t => t.Numero).IsRequired().HasMaxLength(15);
            Property(t => t.Tipo).IsRequired();
        }
    }
}
