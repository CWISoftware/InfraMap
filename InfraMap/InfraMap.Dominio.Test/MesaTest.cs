using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;

namespace InfraMap.Dominio.Test
{
    [TestClass]
    public class MesaTest
    {
        private Usuario.Usuario usuario;
        private Mesa.Mesa mesa;
        private MaquinaPessoal maquina;
        private Ramal ramal;

        public MesaTest()
        {
            usuario = new Usuario.Usuario();
            mesa = new Mesa.Mesa();
            maquina = new MaquinaPessoal();
            ramal = new Ramal();

            usuario.Id = 1;
            mesa.Id = 1;
            maquina.Id = 1;
            ramal.Id = 1;
        }

        [TestMethod]
        public void AdicionarColaborador()
        {
            mesa.AdicionarColaborador(usuario);

            Assert.AreEqual(usuario.Id, mesa.Colaborador_Id);
            Assert.AreEqual(usuario,mesa.Colaborador);
        }

        [TestMethod]
        public void AdicionarColaboradores()
        {
            Usuario.Usuario usuario2 = new Usuario.Usuario();
            Usuario.Usuario usuario3 = new Usuario.Usuario();

            usuario2.Id = 2;
            usuario3.Id = 3;

            mesa.AdicionarColaborador(usuario);
            mesa.AdicionarColaborador(usuario2);
            mesa.AdicionarColaborador(usuario3);

            Assert.AreEqual(usuario3.Id, mesa.Colaborador_Id);
            Assert.AreEqual(usuario3, mesa.Colaborador);
        }

        [TestMethod]
        public void RemoverColaborador()
        {
            mesa.AdicionarColaborador(usuario);
            mesa.RemoverColaborador();

            Assert.AreEqual(null, mesa.Colaborador_Id);
            Assert.AreEqual(null, mesa.Colaborador);
        }

        [TestMethod]
        public void AdicionarMaquina()
        {
            mesa.AdicionarMaquina(maquina);

            Assert.AreEqual(maquina,mesa.MaquinaPessoal);
            Assert.AreEqual(maquina.Id,mesa.MaquinaPessoal_Id);
        }

        [TestMethod]
        public void RemoverMaquina()
        {
            mesa.AdicionarMaquina(maquina);
            mesa.RemoverMaquina();

            Assert.AreEqual(null, mesa.MaquinaPessoal);
            Assert.AreEqual(null, mesa.MaquinaPessoal_Id);
        }

        [TestMethod]
        public void AdicionarRamal()
        {
            mesa.AdicionarRamal(ramal);

            Assert.AreEqual(ramal, mesa.Ramal);
            Assert.AreEqual(ramal.Id, mesa.Ramal_Id);
        }

        [TestMethod]
        public void RemoverRamal()
        {
            mesa.AdicionarRamal(ramal);
            mesa.RemoverRamal();

            Assert.AreEqual(null,mesa.Ramal);
            Assert.AreEqual(null, mesa.Ramal_Id);
        }
    }
}
