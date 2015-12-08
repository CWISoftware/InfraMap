using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void TruncateRetornaPropriaPalavraPorSerMenorQueOTamanhoEspecificado()
        {
            var palavra = "MinhaPalavra";

            var resultado = palavra.Truncate(30);

            Assert.AreEqual(palavra,resultado);
        }

        [TestMethod]
        public void TruncateRetornaPalavraCom10Caracteres()
        {
            var palavra = "MinhaPalavra";

            var resultado = palavra.Truncate(10);

            Assert.AreEqual("MinhaPalav", resultado);
        }
    }
}
