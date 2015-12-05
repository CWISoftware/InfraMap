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
        private readonly string nome;

        public BuscarMaquinaPorNomeQuery(string nome)
        {
            this.nome = nome;
        }

        public IQueryable<Maquina> CriarQuery(IQueryable<Maquina> src)
        {
            return src.Where(t => t.Nome.Equals(this.nome));
        }
    }
}
