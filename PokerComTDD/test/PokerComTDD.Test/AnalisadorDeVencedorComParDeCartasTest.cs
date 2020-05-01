using PokerComTDD.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PokerComTDD.Test
{
    public class AnalisadorDeVencedorComParDeCartasTest
    {
        private readonly AnalisadorDeVencedorComParDeCartasService _service;
        public AnalisadorDeVencedorComParDeCartasTest()
        {
            _service = new AnalisadorDeVencedorComParDeCartasService();

        }

        //[Theory]
        //[InlineData("2O,2C,3P,6C,7C", "3O,5C,2E,9C,7P", "Primeiro Jogador")]
        //[InlineData("3O,5C,2E,9C,7P", "2O,2C,3P,6C,7C", "Segundo Jogador")]
        //[InlineData("2O,2C,3P,6C,7C", "DO,DC,2E,9C,7P", "Segundo Jogador")]
        //[InlineData("DO,DC,2E,9C,7P", "2O,2C,3P,6C,7C", "Primeiro Jogador")]
        //public void DeveAnalisarVencedorQuandoTiverUmParDeCartasDoMesmoValor(string cartasDoPrimeiroJogadorString,
        //           string cartasDoSegundoJogadorString, string vencedorEsperado)
        //{
        //    var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(',').ToList();
        //    var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(',').ToList();

        //    var vencedor = _service.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

        //    Assert.Equal(vencedorEsperado, vencedor);
        //}

        [Fact]
        public void NaoDeveAnalisarVencedorQuandoJogadorNaoTemParDeCartas()
        {
            var cartasDoPrimeiroJogador = "2O,4C,3P,6C,7C".Split(',').ToList();
            var cartasDoSegundoJogador = "3O,5C,2E,9C,7P".Split(',').ToList();

            var vencedor = _service.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            Assert.Null(vencedor);
        }
    }
}
