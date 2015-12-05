using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloMaquina.Queries
{
    public class BuscarMaquinaPorNomeQuery : IQuery<Maquina>
    {
        private readonly string nomeMaquina;

        public BuscarMaquinaPorNomeQuery(string nomeMaquina)
        {
            this.nomeMaquina = nomeMaquina;
        }

        public IQueryable<Maquina> CriarQuery(IQueryable<Maquina> src)
        {
            return src.Where(t => t.Nome.StartsWith(this.nomeMaquina));
        }
    }
}
