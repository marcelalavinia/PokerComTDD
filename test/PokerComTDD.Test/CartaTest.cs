using ExpectedObjects;
using PokerComTDD.Test.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerComTDD.Test
{
    public class CartaTest
    {
        [Theory]
        [InlineData("A", "O", 14)]
        [InlineData("10", "E", 10)]
        [InlineData("2", "P", 2)]
        public void DeveCriarUmaCarta(string valorDaCarta, string naipeDaCarta, int pesoDaCarta)
        {
            var cartaEsperada = new
            {
                Valor = valorDaCarta,
                Naipe = naipeDaCarta,
                Peso = pesoDaCarta
            };

            var carta = new Carta(cartaEsperada.Valor + cartaEsperada.Naipe);

            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }

        [Theory]
        [InlineData("V", 11)]
        [InlineData("D", 12)]
        [InlineData("R", 13)]
        [InlineData("A", 14)]
        public void DeveCriarUmaCartaComPeso(string valorDaCarta, int pesoEperado)
        {
            var carta = new Carta(valorDaCarta + "E");

            Assert.Equal(pesoEperado, carta.Peso);
        }


        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("-1")]
        [InlineData("15")]
        public void DeveValidarValorDaCarta(string valorDaCartaInvalido)
        {
            var mensagemDeErro = Assert.Throws<Exception>(() => new Carta(valorDaCartaInvalido + "O")).Message;

            Assert.Equal("Valor da carta inválida", mensagemDeErro);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("Z")]
        [InlineData("AB")]
        public void DeveValidarNaipeDaCarta(string naipeDaCartaInvalido)
        {
            var mensagemDeErro = Assert.Throws<Exception>(() => new Carta("2" + naipeDaCartaInvalido)).Message;

            Assert.Equal("Naipe da carta inválida", mensagemDeErro);
        }
    }

}
