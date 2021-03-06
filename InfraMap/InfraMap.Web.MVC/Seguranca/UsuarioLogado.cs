﻿using System.Collections.Generic;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Web.MVC.Seguranca
{
    public class UsuarioLogado
    {
        public string Login { get; private set; }

        public List<string> Permissoes { get; private set; }

        public UsuarioLogado(Usuario usuario)
        {
            this.Login = usuario.Login;
            this.Permissoes = usuario.Permissoes;
        }
    }
}
