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
                //TODO - Adicionar nome dos grupos de infra e gerentes do AD.
                if ("dloutrs" == LDAPService.GetUserGroups(usuarioAD.UserName).Find(x => x.Contains("dloutrs")))
                {
                    gruposAD.Add("OUTROS");
                    gruposAD.Add("INFRA");
                    gruposAD.Add("GERENTE");
                }
                return new Usuario.Usuario(usuarioAD.UserName, LDAPService.GetUserDisplayName(usuarioAD.UserName), gruposAD);
            }

            return null;
        }

    }
}
