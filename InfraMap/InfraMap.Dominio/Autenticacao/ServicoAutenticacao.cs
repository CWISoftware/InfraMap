using System.Collections.Generic;
using System.Web.Security;
using InfraMap.Dominio.Usuario;
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
                var permissoesUsuario = new List<string>();
                MembershipUser usuarioAD = Membership.GetUser(login);
                var gruposUsuarioAD = LDAPService.GetUserGroups(usuarioAD.UserName);
                if (gruposUsuarioAD.ContainsKey("OUGrupos") && gruposUsuarioAD["OUGrupos"].Contains("DL gerentes"))
                    permissoesUsuario.Add("GERENTE");
                if (gruposUsuarioAD.ContainsKey("OUGrupos") && gruposUsuarioAD["OUGrupos"].Contains("Infraestrutura CWI"))
                    permissoesUsuario.Add("INFRA");
                if (permissoesUsuario.Count == 0)
                    permissoesUsuario.Add("OUTROS");

                Usuario.Usuario usuario = new Usuario.Usuario(usuarioAD.UserName, LDAPService.GetUserDisplayName(usuarioAD.UserName), permissoesUsuario);
                if (this.usuarioRepositorio.BuscarPorLogin(login) == null)
                    return this.usuarioRepositorio.Adicionar(usuario);
                return usuario;
            }

            return null;
        }

    }
}
