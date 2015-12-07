using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Usuario
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario BuscarPorLogin(string login);

        IList<Usuario> BuscarListaPorNome(string nome);

        Usuario BuscarPorNome(string nome);

        IList<Usuario> BuscarUsuariosPorLogin(string login);
    }
}
