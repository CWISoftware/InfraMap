using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloMaquina.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class MaquinaRepositorio : RepositorioBase<Maquina>, IMaquinaRepositorio
    {
        public IList<Maquina> BuscarPorNome(string nomeMaquina)
        {
            return this.Buscar(new BuscarMaquinaPorNomeQuery(nomeMaquina));
        }
    }
}
