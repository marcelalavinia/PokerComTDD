using Moq;
using PokerComTDD.Test.Interfaces;
using PokerComTDD.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PokerComTDD.Test
{
    public class AnalisadorDeVencedorTest
    {
        private readonly AnalisadorDeVencedorService _analisadorDeVencedorService;
        private readonly Mock<IAnalisadorDeVencedorComMaiorCartaService> _analisadorDeVencedorComMaiorCartaService;
        private readonly Mock<IAnalisadorDeVencedorComParDeCartasService> _analisadorDeVencedorComParDeCartasService;
        private readonly List<string> _cartasDoPrimeiroJogador;
        private readonly List<string> _cartasDoSegundoJogador;

        public AnalisadorDeVencedorTest()
        {
            _analisadorDeVencedorComMaiorCartaService = new Mock<IAnalisadorDeVencedorComMaiorCartaService>();
            _analisadorDeVencedorComParDeCartasService = new Mock<IAnalisadorDeVencedorComParDeCartasService>();

            _analisadorDeVencedorService = new AnalisadorDeVencedorService(
                _analisadorDeVencedorComMaiorCartaService.Object,
                _analisadorDeVencedorComParDeCartasService.Object);

            _cartasDoPrimeiroJogador = "2O,4C,3P,6C,7C".Split(',').ToList();
            _cartasDoSegundoJogador = "3O,5C,2E,9C,7P".Split(',').ToList();
        }

        [Fact]
        public void DeveAnalisarVencedorQueTemMaiorCarta()
        {
            _analisadorDeVencedorComMaiorCartaService
                .Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador))
                .Returns("Segundo Jogador");

            _analisadorDeVencedorService.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

            _analisadorDeVencedorComMaiorCartaService
                .Verify(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador));
        }

        [Fact]
        public void DeveAnalisarVencedorQueTemParDeCartas()
        {
            _analisadorDeVencedorComParDeCartasService
                .Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador))
                .Returns("Segundo Jogador");

            _analisadorDeVencedorService.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

            _analisadorDeVencedorComParDeCartasService
                .Verify(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador));
        }

        [Fact]
        public void NaoDeveAnalisarVencedorComMaiorCartaQuandoJogadaTerCartasComPar()
        {
            _analisadorDeVencedorComParDeCartasService
                .Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador))
                .Returns("Segundo Jogador");

            _analisadorDeVencedorService.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

            _analisadorDeVencedorComMaiorCartaService
                .Verify(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador), Times.Never);
        }
    }

}
