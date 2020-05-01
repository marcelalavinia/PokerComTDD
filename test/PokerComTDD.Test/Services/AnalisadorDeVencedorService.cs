using PokerComTDD.Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerComTDD.Test.Services
{
    public class AnalisadorDeVencedorService
    {
        private readonly IAnalisadorDeVencedorComMaiorCartaService _analisadorDeVencedorComMaiorCartaService;
        private readonly IAnalisadorDeVencedorComParDeCartasService _analisadorDeVencedorComParDeCartasService;
        public AnalisadorDeVencedorService(
            IAnalisadorDeVencedorComMaiorCartaService analisadorDeVencedorComMaiorCartaService,
            IAnalisadorDeVencedorComParDeCartasService analisadorDeVencedorComParDeCartasService)
        {
            _analisadorDeVencedorComMaiorCartaService = analisadorDeVencedorComMaiorCartaService;
            _analisadorDeVencedorComParDeCartasService = analisadorDeVencedorComParDeCartasService;
        }

        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var vencedor = _analisadorDeVencedorComParDeCartasService.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            if (vencedor == null)
                vencedor = _analisadorDeVencedorComMaiorCartaService.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            return vencedor;
        }

    }
}
