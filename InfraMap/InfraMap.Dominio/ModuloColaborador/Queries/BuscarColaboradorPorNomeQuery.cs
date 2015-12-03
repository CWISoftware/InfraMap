using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloColaborador.Queries
{
    public class BuscarColaboradorPorNomeQuery : IQuery<Colaborador>
    {
        private readonly string nome;

        public BuscarColaboradorPorNomeQuery(string nome)
        {
            this.nome = nome;
        }

        public IQueryable<Colaborador> CriarQuery(IQueryable<Colaborador> src)
        {
            return src.Where(t => t.Usuario.Nome.StartsWith(nome));
        }
    }
}
