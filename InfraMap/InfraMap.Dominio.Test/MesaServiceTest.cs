using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using InfraMap.Dominio.Mesa;
using InfraMap.Dominio.Usuario;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;

namespace InfraMap.Dominio.Test
{
    [TestClass]
    public class MesaServiceTest
    {
        private IMesaRepositorio mesaRepositorio;
        private IUsuarioRepositorio usuarioRepositorio;
        private IMaquinaRepositorio maquinaRepositorio;
        private IRamalRepositorio ramalRepositorio;
        private IModeloMaquinaRepositorio modeloMaquinaRepositorio;
        private IMaquinaPessoalRepositorio maquinaPessoalRepositorio;

        private Usuario.Usuario usuarioFake;
        private Mesa.Mesa mesaFake;
        private MaquinaPessoal maquinaPessoalFake;
        private ModeloMaquina modeloMaquinaFake;
        private Maquina maquinaFake;
        private Ramal ramalFake;

        private MesaService mesaService;

        public MesaServiceTest()
        {
            usuarioFake = new Usuario.Usuario();
            mesaFake = new Mesa.Mesa();
            maquinaPessoalFake = new MaquinaPessoal();
            modeloMaquinaFake = new ModeloMaquina();
            maquinaFake = new Maquina();
            ramalFake = new Ramal();

            mesaFake.Id = 1;

            usuarioFake.Login = "usuario.usuario";
            usuarioFake.Nome = "Usuário";
            usuarioFake.Id = 1;

            modeloMaquinaFake.Id = 1;

            ramalFake.Id = 1;
            ramalFake.Numero = "9999";
            ramalFake.Tipo = TipoRamal.Analogico;
        }

        private void Inicializa()
        {
            mesaRepositorio = A.Fake<IMesaRepositorio>();
            usuarioRepositorio = A.Fake<IUsuarioRepositorio>();
            maquinaRepositorio = A.Fake<IMaquinaRepositorio>();
            ramalRepositorio = A.Fake<IRamalRepositorio>();
            modeloMaquinaRepositorio = A.Fake<IModeloMaquinaRepositorio>();
            maquinaPessoalRepositorio = A.Fake<IMaquinaPessoalRepositorio>();

            mesaService = new MesaService(
                mesaRepositorio,
                usuarioRepositorio,
                maquinaRepositorio,
                ramalRepositorio,
                modeloMaquinaRepositorio,
                maquinaPessoalRepositorio
                );
        }

        [TestMethod]
        public void AdicionarColaborador()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorNome(usuarioFake.Nome)).Returns(usuarioFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(usuarioFake.Login)).Returns(null);

            mesaService.AdicionarColaborador(mesaFake.Id, usuarioFake.Nome);

            Assert.AreEqual(usuarioFake,mesaFake.Colaborador);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Colaborador não encontrado!")]
        public void AdicionarColaboradorNulo()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorNome("")).Returns(null);
            A.CallTo(() => usuarioRepositorio.Adicionar(null)).Returns(null);

            mesaService.AdicionarColaborador(mesaFake.Id, "");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioEmOutraMesaException))]
        public void AdicionarColaboradorEmOutraMesa()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorNome(usuarioFake.Nome)).Returns(usuarioFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(usuarioFake.Login)).Returns(mesaFake);


            mesaService.AdicionarColaborador(mesaFake.Id, usuarioFake.Nome);
        }

        [TestMethod]
        public void TrocarColaborador()
        {
            Inicializa();

            Mesa.Mesa mesaFakeAtual = new Mesa.Mesa();
            mesaFakeAtual.Id = 2;
            mesaFakeAtual.AdicionarColaborador(usuarioFake);

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorNome(usuarioFake.Nome)).Returns(usuarioFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(usuarioFake.Login)).Returns(mesaFakeAtual);

            mesaService.TrocarColaborador(mesaFake.Id, usuarioFake.Nome);

            Assert.AreEqual(null,mesaFakeAtual.Colaborador);
            Assert.AreEqual(usuarioFake, mesaFake.Colaborador);
        }

        [TestMethod]
        public void TrocarColaboradorSemMesa()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);
            A.CallTo(() => usuarioRepositorio.BuscarPorNome(usuarioFake.Nome)).Returns(usuarioFake);
            A.CallTo(() => mesaRepositorio.BuscarMesaPorColaborador(usuarioFake.Login)).Returns(null);

            mesaService.TrocarColaborador(mesaFake.Id, usuarioFake.Nome);

            Assert.AreEqual(null, mesaFake.Colaborador);
        }

        [TestMethod]
        public void RemoverColaborador()
        {
            Inicializa();

            mesaFake.AdicionarColaborador(usuarioFake);

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.RemoverColaborador(mesaFake.Id);

            Assert.AreEqual(null, mesaFake.Colaborador);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Esta mesa não tem colaborador!")]
        public void RemoverColaboradorSemMesa()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.RemoverColaborador(mesaFake.Id);

            Assert.AreEqual(null, mesaFake.Colaborador);
        }

        [TestMethod]
        public void AdicionarMaquinaPessoal()
        {
            Inicializa();

            maquinaFake.AdicionarModelo(modeloMaquinaFake);
            maquinaPessoalFake.Maquina = maquinaFake;

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);
            A.CallTo(() => modeloMaquinaRepositorio.BuscarPorId((int)maquinaPessoalFake.Maquina.ModeloMaquina_Id)).Returns(modeloMaquinaFake);
            A.CallTo(() => maquinaPessoalRepositorio.Adicionar(maquinaPessoalFake)).Returns(maquinaPessoalFake);

            mesaService.AdicionarMaquina(mesaFake.Id, maquinaPessoalFake);

            Assert.AreEqual(maquinaPessoalFake, mesaFake.MaquinaPessoal);
        }

        [TestMethod]
        public void RemoverMaquinaPessoal()
        {
            Inicializa();

            mesaFake.AdicionarMaquina(maquinaPessoalFake);

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.RemoverMaquina(mesaFake.Id);

            Assert.AreEqual(null, mesaFake.MaquinaPessoal);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Esta mesa não possui maquina!")]
        public void RemoverMaquinaSemMaquina()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.RemoverMaquina(mesaFake.Id);
        }

        [TestMethod]
        public void AdicionarRamal()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.AdicionarRamal(mesaFake.Id, ramalFake.Numero, (int)ramalFake.Tipo);

            Assert.AreNotEqual(null, mesaFake.Ramal);
        }

        [TestMethod]
        public void RemoverRamal()
        {
            Inicializa();

            mesaFake.AdicionarRamal(ramalFake);

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.RemoverRamal(mesaFake.Id);

            Assert.AreEqual(null, mesaFake.Ramal);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Esta mesa não possui ramal!")]
        public void RemoverRamalSemRamal()
        {
            Inicializa();

            A.CallTo(() => mesaRepositorio.BuscarPorId(mesaFake.Id)).Returns(mesaFake);

            mesaService.RemoverRamal(mesaFake.Id);

            Assert.AreEqual(null, mesaFake.Ramal);
        }
    }
}
