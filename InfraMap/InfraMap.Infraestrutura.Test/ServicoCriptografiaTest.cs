using InfraMap.Infraestrutura.Criptografia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Test
{
    [TestClass]
    public class ServicoCriptografiaTest
    {
        [TestMethod]
        public void CriptografaSenha123()
        {
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();

            string resultado = servicoCriptografia.CriptografarSenha("123");

            Assert.AreEqual("ae46998f4fe09e25ca20fca3c3839b3c", resultado.ToLower());
        }
    }
}
