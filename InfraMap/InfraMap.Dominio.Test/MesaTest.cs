using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.Test
{
    [TestClass]
    public class MesaTest
    {
        [TestMethod]
        public void AdicionaColaboradorComSucesso()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Usuario.Usuario usuario = new Usuario.Usuario();
            usuario.Id = 1;

            mesa.AdicionarColaborador(usuario);

            Assert.AreEqual(1,mesa.Colaborador_Id);
            Assert.AreEqual(usuario,mesa.Colaborador);
        }

        [TestMethod]
        public void AdicionaTresColaboradoresEVerificaSeFicouUltimo()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Usuario.Usuario usuario1 = new Usuario.Usuario();
            usuario1.Id = 1;

            Usuario.Usuario usuario2 = new Usuario.Usuario();
            usuario2.Id = 3;

            Usuario.Usuario usuario3 = new Usuario.Usuario();
            usuario3.Id = 5;

            mesa.AdicionarColaborador(usuario1);
            mesa.AdicionarColaborador(usuario2);
            mesa.AdicionarColaborador(usuario3);

            Assert.AreEqual(5, mesa.Colaborador_Id);
            Assert.AreEqual(usuario3, mesa.Colaborador);
        }

        [TestMethod]
        public void RemoveColaboradorComSucesso()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Usuario.Usuario usuario = new Usuario.Usuario();
            usuario.Id = 1;
            mesa.AdicionarColaborador(usuario);

            mesa.RemoverColaborador();

            Assert.AreEqual(null, mesa.Colaborador_Id);
            Assert.AreEqual(null, mesa.Colaborador);
        }

        [TestMethod]
        public void AdicionaMaquinaNaMesa()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Maquina maquina = new Maquina();
            maquina.Id = 1;

            //mesa.AdicionarMaquina(maquina);

            //Assert.AreEqual(maquina,mesa.Maquina);
            //Assert.AreEqual(maquina.Id,mesa.Maquina_Id);
        }

        [TestMethod]
        public void RemoveMaquinaDaMesa()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Maquina maquina = new Maquina();
            maquina.Id = 1;
            //mesa.AdicionarMaquina(maquina);

            //mesa.RemoverMaquina();

            //Assert.AreEqual(null, mesa.Maquina);
            //Assert.AreEqual(null, mesa.Maquina_Id);
        }

        [TestMethod]
        public void AdicionarRamalNaMesa()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Ramal ramal = new Ramal();
            ramal.Id = 1;

            mesa.AdicionarRamal(ramal);

            Assert.AreEqual(ramal, mesa.Ramal);
            Assert.AreEqual(1,mesa.Ramal_Id);
        }

        [TestMethod]
        public void RemoverRamalDaMesa()
        {
            Mesa.Mesa mesa = new Mesa.Mesa();
            Ramal ramal = new Ramal();
            ramal.Id = 1;
            mesa.AdicionarRamal(ramal);

            mesa.RemoverRamal();

            Assert.AreEqual(null,mesa.Ramal);
            Assert.AreEqual(null, mesa.Ramal_Id);
        }
    }
}
