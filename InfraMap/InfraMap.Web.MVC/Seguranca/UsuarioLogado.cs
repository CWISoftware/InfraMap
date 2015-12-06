using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Web.MVC.Seguranca
{
    public class UsuarioLogado
    {
        public string Login { get; private set; }

        public string[] Permissoes { get; private set; }

        public UsuarioLogado(Usuario usuario)
        {
            this.Login = usuario.Login;
            this.Permissoes = usuario.Permissoes.Select(p => p.Texto).ToArray();
        }

        public bool TemPermissao(string nomePermissao)
        {
            return this.Permissoes != null
                && this.Permissoes.Contains(nomePermissao);
        }

    }
}
