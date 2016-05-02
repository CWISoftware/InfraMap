using System.Collections.Generic;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Usuario
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario BuscarPorLogin(string login);

        IList<Usuario> BuscarListaPorNome(string nome);

        Usuario BuscarPorNome(string nome);

        IList<Usuario> BuscarUsuariosPorLogin(string login);

        IList<Usuario> Buscar();

        Usuario BuscarPorCor(string color);
    }
}
