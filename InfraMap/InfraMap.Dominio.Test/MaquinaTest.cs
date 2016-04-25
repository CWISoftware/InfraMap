using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfraMap.Dominio.Mesa.Maquina;

namespace InfraMap.Dominio.Test
{
    [TestClass]
    public class MaquinaTest
    {
        private Maquina maquina;
        private ModeloMaquina modelo;

        public MaquinaTest()
        {
            maquina = new Maquina();
            modelo = new ModeloMaquina();

            modelo.Id = 1;
        }

       [TestMethod]
        public void AdicionarModelo()
        {
            maquina.AdicionarModelo(modelo);

            Assert.AreEqual(modelo, maquina.ModeloMaquina);
            Assert.AreEqual(modelo.Id, maquina.ModeloMaquina_Id);
        }

        [TestMethod]
        public void RemoverModelo()
        {
            maquina.AdicionarModelo(modelo);
            maquina.RemoverModelo();

            Assert.AreEqual(null, maquina.ModeloMaquina);
            Assert.AreEqual(null, maquina.ModeloMaquina_Id);
        }
    }
}
