using FakeItEasy;
using InfraMap.Dominio.Autenticacao;
using InfraMap.Dominio.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Test
{
    [TestClass]
    public class ServicoAutenticacaoTest
    {
        [TestMethod]
        public void BuscaAutenticacaoPorLoginQueNaoExiste()
        {
            var servicoCriptografia = A.Fake<IServicoCriptografia>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            string login = "usuario.usuario";
            string senha = "123";
            A.CallTo(()=>usuarioRepositorio.BuscarPorLogin(login)).Returns(null);
            ServicoAutenticacao servAut = new ServicoAutenticacao(usuarioRepositorio,servicoCriptografia);

            Usuario.Usuario resultado = servAut.BuscarPorAutenticacao(login,senha);

            Assert.AreEqual(null,resultado);
        }

        [TestMethod]
        public void BuscaAutenticacaoPorLoginMasSenhaEstaErrada()
        {
            var servicoCriptografia = A.Fake<IServicoCriptografia>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            Usuario.Usuario usuario = new Usuario.Usuario();
            usuario.Senha = "123";
            string login = "usuario.usuario";
            string senha = "123";
            A.CallTo(() => usuarioRepositorio.BuscarPorLogin(login)).Returns(usuario);
            A.CallTo(() => servicoCriptografia.CriptografarSenha(senha)).Returns("124");
            ServicoAutenticacao servAut = new ServicoAutenticacao(usuarioRepositorio, servicoCriptografia);

            Usuario.Usuario resultado = servAut.BuscarPorAutenticacao(login, senha);

            Assert.AreEqual(null, resultado);
        }

        [TestMethod]
        public void BuscaAutenticacaoPorLoginERetornaSucesso()
        {
            var servicoCriptografia = A.Fake<IServicoCriptografia>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            Usuario.Usuario usuario = new Usuario.Usuario();
            usuario.Senha = "123";
            string login = "usuario.usuario";
            string senha = "123";
            A.CallTo(() => usuarioRepositorio.BuscarPorLogin(login)).Returns(usuario);
            A.CallTo(() => servicoCriptografia.CriptografarSenha(senha)).Returns("123");
            ServicoAutenticacao servAut = new ServicoAutenticacao(usuarioRepositorio, servicoCriptografia);

            Usuario.Usuario resultado = servAut.BuscarPorAutenticacao(login, senha);

            Assert.AreEqual(usuario, resultado);
        }

    }
}
