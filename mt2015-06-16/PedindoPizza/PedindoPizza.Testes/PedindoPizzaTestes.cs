using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PedindoPizza.Testes
{
    [TestFixture]
    public class PedindoPizzaTestes
    {        
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(6)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AvaliacaoInvalidaLancaExcecao(int nota)
        {
            Pizza pizza = new Pizza();
            var pedindoPizza = new PedindoPizza();

            pedindoPizza.Avaliar(new Pessoa(), pizza, nota);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void AvaliacaoValidaE_RegistradaParaA_Pizza(int nota)
        {
            Pizza pizza = new Pizza();
            var pedirPizza = new PedindoPizza();
            pedirPizza.Avaliar(new Pessoa(), pizza, nota);
            Assert.AreEqual(nota, pizza.nota);
        }

        [Test]
        public void AvaliacaoValidaMediaDeNotasAtribuidas()
        {
            Pizza pizza = new Pizza();
            var pedirPizza = new PedindoPizza();
            pedirPizza.Avaliar(new Pessoa(), pizza, 1);
            pedirPizza.Avaliar(new Pessoa(), pizza, 2);
            pedirPizza.Avaliar(new Pessoa(), pizza, 5);
            
            Assert.AreEqual(3, pizza.totalVoto);
            Assert.AreEqual(2, pizza.media);
        }

        [Test]
        public void TodasAsPessoasVotaramEmTodasAsPizzasO_RankingEhProcessado()
        {
            
            var pessoa1 = new Pessoa();
            var pessoa2 = new Pessoa();
            var pessoasNaReuniao = new List<Pessoa> { pessoa1, pessoa2 };
            
            var pizza1 = new Pizza();

            var pizza2 = new Pizza();

            var pizzasRankeadasEsperado = new List<Pizza>();
            pizzasRankeadasEsperado.Add(pizza2);
            pizzasRankeadasEsperado.Add(pizza1);

            var opcoesPizzas = new List<Pizza> { pizza1, pizza2 };
            var pizzasRankeadas = new List<Pizza>();

            PedindoPizza pedindoPizza = new PedindoPizza(pessoasNaReuniao, opcoesPizzas);
            pedindoPizza.Avaliar(pessoa1, pizza1, 1);
            pedindoPizza.Avaliar(pessoa1, pizza2, 5);
            pedindoPizza.Avaliar(pessoa2, pizza1, 5);
            pedindoPizza.Avaliar(pessoa2, pizza2, 3);

            pizzasRankeadas = pedindoPizza.ProcessarRanking();

            Assert.AreEqual(pizzasRankeadasEsperado, pizzasRankeadas);
        }
    }
}
