using PokerComTDD.Test.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerComTDD.Test.Services
{
    public class AnalisadorDeVencedorComParDeCartasService
    {
        public AnalisadorDeVencedorComParDeCartasService()
        {

        }
        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var parDeCartasDoPrimeiroJogador = cartasDoPrimeiroJogador
                .Select(carta => new Carta(carta).Peso)
                .GroupBy(peso => peso)
                .Where(grupo => grupo.Count() > 1);

            var parDeCartasDoSegundoJogador = cartasDoSegundoJogador
                 .Select(carta => new Carta(carta).Peso)
                 .GroupBy(peso => peso)
                 .Where(grupo => grupo.Count() > 1);

            if (parDeCartasDoPrimeiroJogador != null && parDeCartasDoPrimeiroJogador.Any() &&
               parDeCartasDoSegundoJogador != null && parDeCartasDoSegundoJogador.Any())
            {
                var maiorParDeCartasDoPrimeiroJogador = parDeCartasDoPrimeiroJogador
                    .Select(carta => carta.Key).OrderBy(valorDaCarta => valorDaCarta)
                    .Max();

                var maiorParDeCartasDoSegundoJogador = parDeCartasDoSegundoJogador
                   .Select(carta => carta.Key).OrderBy(valorDaCarta => valorDaCarta)
                   .Max();

                if (maiorParDeCartasDoPrimeiroJogador > maiorParDeCartasDoSegundoJogador)
                    return "Primeiro Jogador";
                else if (maiorParDeCartasDoSegundoJogador > maiorParDeCartasDoPrimeiroJogador)
                    return "Segundo Jogador";
            }
            else if (parDeCartasDoPrimeiroJogador != null && parDeCartasDoPrimeiroJogador.Any())
                return "Primeiro Jogador";


            return null;
        }


    }
}
