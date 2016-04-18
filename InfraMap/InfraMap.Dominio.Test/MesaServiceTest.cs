using FakeItEasy;
using InfraMap.Dominio.Mesa;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
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
    public class MesaServiceTest
    {
        [TestMethod]
        public void AdicionaColaboradorComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            var login = "usuario.usuario";
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            Usuario.Usuario usuarioFake = new Usuario.Usuario();
            usuarioFake.Login = login;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorLogin(login)).Returns(usuarioFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(usuarioFake.Login)).Returns(null);
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio,usuarioRepositorio,maquinaRepositorio,ramalRepositorio);

            //mesaService.AdicionarColaborador(1,login);

            Assert.AreEqual(usuarioFake,mesaFake.Colaborador);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Colaborador não encontrado!")]
        public void TentaAdicionarColaboradorNuloComInsucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            var login = "usuario.usuario";
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            Usuario.Usuario usuarioFake = new Usuario.Usuario();
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorLogin(login)).Returns(null);
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);

            //mesaService.AdicionarColaborador(1, login);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioEmOutraMesaException), "Colaborador usuario.usuario já está em outra mesa!")]
        public void TentaAdicionarColaboradorQueJaEstaEmOutraMesa()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            var login = "usuario.usuario";
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            Usuario.Usuario usuarioFake = new Usuario.Usuario();
            usuarioFake.Login = login;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorLogin(login)).Returns(usuarioFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(usuarioFake.Login)).Returns(mesaFake);
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);

            //mesaService.AdicionarColaborador(1, login);
        }

        [TestMethod]
        public void TrocaColaboradorComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            var login = "usuario.usuario";
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            Mesa.Mesa mesaFakeAtual = new Mesa.Mesa();
            Usuario.Usuario usuario = new Usuario.Usuario();
            mesaFakeAtual.Colaborador = usuario;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(login)).Returns(mesaFakeAtual);
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFakeAtual)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);

            //mesaService.TrocarColaborador(1, login);

            Assert.AreEqual(null,mesaFakeAtual.Colaborador);
            Assert.AreEqual(usuario, mesaFake.Colaborador);
        }

        [TestMethod]
        public void TentaTrocarColaboradorQueNaoEstaNumaMesa()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            var login = "usuario.usuario";
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            mesaFake.Colaborador = null;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(login)).Returns(null);
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);

            //mesaService.TrocarColaborador(1, login);

            Assert.AreEqual(null, mesaFake.Colaborador);
        }

        [TestMethod]
        public void RemoverColaboradorComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            mesaFake.Colaborador = new Usuario.Usuario();
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);

            //mesaService.RemoverColaborador(1);

            Assert.AreEqual(null, mesaFake.Colaborador);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Esta mesa não tem colaborador!")]
        public void TentaRemoverColaboradorDeMesaQueNaoTemColaborador()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            mesaFake.Colaborador = null;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);

            //mesaService.RemoverColaborador(1);
        }

        [TestMethod]
        public void AdicionarMaquinaNaMesaComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            Maquina maquinaFake = new Maquina();
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            //A.CallTo(() => maquinaRepositorio.Adicionar(maquinaFake)).DoesNothing();
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);
            var tipoMaquina = 1;
            var idMesa = 1;
            var nomeMaquina = "MinhaMaquina";

            //mesaService.AdicionarMaquina(idMesa, nomeMaquina, tipoMaquina);

            //Assert.AreNotEqual(null,mesaFake.Maquina);
        }

        [TestMethod]
        public void RemoverMaquinaDaMesaComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            //mesaFake.Maquina = new Maquina();
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);
            var idMesa = 1;

            //mesaService.RemoverMaquina(idMesa);

            //Assert.AreEqual(null, mesaFake.Maquina);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Esta mesa não possui maquina!")]
        public void TentaRemoverMaquinaDaMesaQueNaoTemMaquina()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            //mesaFake.Maquina = null;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);
            var idMesa = 1;

            //mesaService.RemoverMaquina(idMesa);
        }

        [TestMethod]
        public void AdicionarRamalNaMesaComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            Ramal ramalFake = new Ramal();
            var tipoRamal = 0;
            var idMesa = 1;
            var nomeRamal = "MeuRamal";
            A.CallTo(() => mesaRepositorio.BuscarPorId(idMesa)).Returns(mesaFake);
            //A.CallTo(() => ramalRepositorio.Adicionar(ramalFake)).DoesNothing();
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);            

            //mesaService.AdicionarRamal(idMesa,nomeRamal,tipoRamal);

            Assert.AreNotEqual(null, mesaFake.Ramal);
        }

        [TestMethod]
        public void RemoverRamalNaMesaComSucesso()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            mesaFake.Ramal = new Ramal();
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);
            var idMesa = 1;

            //mesaService.RemoverRamal(idMesa);

            Assert.AreEqual(null, mesaFake.Ramal);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Esta mesa não possui ramal!")]
        public void TentaRemoverRamalNaMesaQueNaoTemRamal()
        {
            var ramalRepositorio = A.Fake<IRamalRepositorio>();
            var usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            var maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            var mesaRepositorio = A.Fake<IMesaRepositorio>();
            Mesa.Mesa mesaFake = new Mesa.Mesa();
            mesaFake.Ramal = null;
            A.CallTo(() => mesaRepositorio.BuscarPorId(1)).Returns(mesaFake);
            A.CallTo(() => mesaRepositorio.Atualizar(mesaFake)).DoesNothing();
            //MesaService mesaService = new MesaService(mesaRepositorio, usuarioRepositorio, maquinaRepositorio, ramalRepositorio);
            var idMesa = 1;

            //mesaService.RemoverRamal(idMesa);
        }
    }
}
