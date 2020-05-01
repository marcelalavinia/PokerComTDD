using PokerComTDD.Test.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerComTDD.Test.Services
{
    public class AnalisadorDeVencedorComMaiorCartaService
    {
        public AnalisadorDeVencedorComMaiorCartaService()
        {

        }
        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var cartaComMaiorPesoDoPrimeiroJogador = cartasDoPrimeiroJogador
                .Select(carta => new Carta(carta).Peso)
                .OrderBy(peso => peso)
                .Max();

            var cartaComMaiorPesoDoSegundoJogador = cartasDoSegundoJogador
               .Select(carta => new Carta(carta).Peso)
               .OrderBy(peso => peso)
               .Max();


            return cartaComMaiorPesoDoPrimeiroJogador > cartaComMaiorPesoDoSegundoJogador ? "Primeiro Jogador" : "Segundo Jogador";
        }
       }
}
