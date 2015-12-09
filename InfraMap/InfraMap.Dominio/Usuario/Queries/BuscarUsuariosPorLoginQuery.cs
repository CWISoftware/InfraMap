using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Usuario.Queries
{
    public class BuscarUsuariosPorLoginQuery : IQuery<Usuario>
    {
        private string login;

        public BuscarUsuariosPorLoginQuery(string login)
        {
            this.login = login;
        }

        public IQueryable<Usuario> CriarQuery(IQueryable<Usuario> src)
        {
            return src.Where(t => t.Login.StartsWith(this.login));
        }
    }
}
