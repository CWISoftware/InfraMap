using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloUsuario.Queries
{
    public class BuscarUsuarioPorNomeQuery : IQuery<Usuario>
    {
        private readonly string nome;

        public BuscarUsuarioPorNomeQuery(string nome)
        {
            this.nome = nome;        
        }

        public IQueryable<Usuario> CriarQuery(IQueryable<Usuario> src)
        {
            return src.Where(t => t.Nome.StartsWith(this.nome));
        }
    }
}
