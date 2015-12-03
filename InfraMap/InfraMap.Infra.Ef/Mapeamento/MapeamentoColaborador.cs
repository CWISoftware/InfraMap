using InfraMap.Dominio.ModuloColaborador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoColaborador : MapeamentoEntidade<Colaborador>
    {
        public MapeamentoColaborador()
        {
            HasRequired(t => t.Usuario).WithMany();
            HasRequired(t => t.Gerente).WithMany();
        }
    }
}
