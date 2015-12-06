using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Maquina.Queries;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class MaquinaRepositorio : RepositorioBase<Maquina>, IMaquinaRepositorio
    {
        public IList<Maquina> BuscarListaPorNome(string nomeMaquina)
        {
            return this.Buscar(new BuscarMaquinasPorNomeQuery(nomeMaquina));
        }


        public Maquina BuscarPorNome(string nomeMaquina)
        {
            return this.Buscar(new BuscarMaquinaPorNomeQuery(nomeMaquina)).FirstOrDefault();
        }
    }
}
