using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class CaixaEletronicaTeste
    {
        CaixaEletronico saque = new CaixaEletronico();
        
        [TestMethod]
        public void Saque_100Reais_Recebe1Nota100()
        {
            var notas = saque.RealizaSaque(100);

            RealizaAsserts_se_QtdeNotas_igual_um_e_ValorNota_correspondente_Cenario(notas, 100);
        }

        [TestMethod]
        public void Saque_50Reais_Recebe1Nota50()
        {
            var notas = saque.RealizaSaque(50);
            RealizaAsserts_se_QtdeNotas_igual_um_e_ValorNota_correspondente_Cenario(notas, 50);
        }

        [TestMethod]
        public void Saque_20Reais_Recebe1Nota20()
        {
            var notas = saque.RealizaSaque(20);
            RealizaAsserts_se_QtdeNotas_igual_um_e_ValorNota_correspondente_Cenario(notas, 20);
        }

        [TestMethod]
        public void Saque_10Reais_Recebe1Nota10()
        {
            var notas = saque.RealizaSaque(10);
            RealizaAsserts_se_QtdeNotas_igual_um_e_ValorNota_correspondente_Cenario(notas, 10);
        }

        [TestMethod]
        public void Saque_40_Reais_Recebe_2_notas_de_20_reais()
        {
            var notas = saque.RealizaSaque(40);

            Assert.AreEqual(notas.Count, 2);
            Assert.AreEqual(notas[0].Valor, 20);
            Assert.AreEqual(notas[1].Valor, 20);
        }

        [TestMethod]
        public void Saque_150_Reais_Recebe_1_Nota_De_100_E_1_Nota_De_50()
        {
            var notas = saque.RealizaSaque(150);

            Assert.AreEqual(notas.Count, 2);
            Assert.AreEqual(notas[0].Valor, 100);
            Assert.AreEqual(notas[1].Valor, 50);
        }

        [TestMethod]
        public void Saque_180_Reais_Recebe_1_Nota_De_Cada_Disponivel()
        {
            var notas = saque.RealizaSaque(180);

            Assert.AreEqual(notas.Count, 4);
            Assert.AreEqual(notas[0].Valor, 100);
            Assert.AreEqual(notas[1].Valor, 50);
            Assert.AreEqual(notas[2].Valor, 20);
            Assert.AreEqual(notas[3].Valor, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Saque_Menor_Que_O_Valor_Da_Menor_Nota_Disponivel()
        {
            var notas = saque.RealizaSaque(-20);
        }

        private void RealizaAsserts_se_QtdeNotas_igual_um_e_ValorNota_correspondente_Cenario(List<Nota> notas, int valor)
        {
            Assert.AreEqual(notas.Count, 1);
            Assert.AreEqual(notas[0].Valor, valor);
        }
    }
}
