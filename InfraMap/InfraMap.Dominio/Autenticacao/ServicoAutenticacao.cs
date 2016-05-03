using InfraMap.Dominio.Usuario;
using System.Collections.Generic;
using System.Web.Security;
using InfraMap.Dominio.LDAP;

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
            if (Membership.ValidateUser(login,senha))
            {
                MembershipUser usuarioAD = Membership.GetUser(login);
                var gruposAD = new List<string>();
                if ("DLgerentes" == LDAPService.GetUserGroups(usuarioAD.UserName).Find(x => x.Contains("DLgerentes")))
                    gruposAD.Add("GERENTE");
                if ("dloutrs" == LDAPService.GetUserGroups(usuarioAD.UserName).Find(x => x.Contains("dloutrs")))
                    gruposAD.Add("OUTROS");

                //-- TODO - Adicionar nome dos grupos de infra e gerentes do AD.
                gruposAD.Add("INFRA");
                //-------------------------------------------------------------

                Usuario.Usuario usuario = new Usuario.Usuario(usuarioAD.UserName, LDAPService.GetUserDisplayName(usuarioAD.UserName), gruposAD);
                if (this.usuarioRepositorio.BuscarPorLogin(login) == null)
                    return this.usuarioRepositorio.Adicionar(usuario);
                return usuario;
            }

            return null;
        }

    }
}
