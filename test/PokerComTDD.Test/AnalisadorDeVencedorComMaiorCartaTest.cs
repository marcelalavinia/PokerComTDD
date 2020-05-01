using PokerComTDD.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PokerComTDD.Test
{
    public class AnalisadorDeVencedorComMaiorCartaTest
    {
        private readonly AnalisadorDeVencedorComMaiorCartaService _service;
        public AnalisadorDeVencedorComMaiorCartaTest()
        {
            _service = new AnalisadorDeVencedorComMaiorCartaService();

        }

        [Theory]
        [InlineData("2O,4C,3P,6C,7C", "3O,5C,2E,9C,7P", "Segundo Jogador")]
        [InlineData("3O,5C,2E,9C,7P", "2O,4C,3P,6C,7C", "Primeiro Jogador")]
        [InlineData("3O,5C,2E,9C,7P", "2O,4C,3P,6C,10E", "Segundo Jogador")]
        [InlineData("3O,5C,2E,9C,7P", "2O,4C,3P,6C,AE", "Segundo Jogador")]
        public void DeveAnalisarVencedorQuandoTiverMaiorCarta(string cartasDoPrimeiroJogadorString,
            string cartasDoSegundoJogadorString, string vencedorEsperado)
        {
            var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(',').ToList();
            var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(',').ToList();

            var vencedor = _service.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);
            Assert.Equal(vencedorEsperado, vencedor);
        }

    }
}
