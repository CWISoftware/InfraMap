﻿using InfraMap.Dominio.ModuloUsuario;
using InfraMap.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Servicos
{
    public class ServicoAutenticacao
    {
        private IUsuarioRepositorio usuarioRepositorio;
        private IServicoCriptografia servicoCriptografia;

        public ServicoAutenticacao(IUsuarioRepositorio usuarioRepositorio, IServicoCriptografia servicoCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public Usuario BuscarPorAutenticacao(string login, string senha)
        {
            Usuario usuario = this.usuarioRepositorio.BuscarPorLogin(login);

            if (usuario != null)
            {
                string senhaCriptografada = servicoCriptografia.CriptografarSenha(senha);

                if (usuario.Senha.ToUpper() != senhaCriptografada)
                {
                    return null;
                }
            }

            return usuario;
        }

    }
}
