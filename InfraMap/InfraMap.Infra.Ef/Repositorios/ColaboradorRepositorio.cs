using InfraMap.Dominio.ModuloColaborador;
using InfraMap.Dominio.ModuloColaborador.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    class ColaboradorRepositorio : RepositorioBase<Colaborador>, IColaboradorRepositorio
    {
        public IList<Colaborador> BuscarPorNome(string nome)
        {
            return this.Buscar(new BuscarColaboradorPorNomeQuery(nome));
        }
    }
}
