using InfraMap.Dominio.Usuario;
using System.Web.Security;

namespace InfraMap.Dominio.Autenticacao
{
    public class ServicoAutenticacao
    {
        private IUsuarioRepositorio usuarioRepositorio;

        public ServicoAutenticacao(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario.Usuario BuscarPorAutenticacao(string login, string senha)
        {
            //if (Membership.ValidateUser(login,senha))
            {
                Usuario.Usuario usuario = this.usuarioRepositorio.BuscarPorLogin(login);

                if(usuario == null)
                {
                    var usuarioAD = Membership.GetUser(login);
                    var usuarioLogado = new Usuario.Usuario()
                    {
                        Login = usuarioAD.UserName,
                        Nome = usuarioAD.ProviderName
                    };
                    return this.usuarioRepositorio.Adicionar(usuarioLogado);
                }
                return usuario;
            }

            return null;
        }

    }
}
