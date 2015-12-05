using InfraMap.Comum;
using InfraMap.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario BuscarPorLogin(string login);

        IList<Usuario> BuscarListaPorNome(string nome);

        Usuario BuscarPorNome(string nome);
    }
}
