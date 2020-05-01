using System;
using System.Collections.Generic;
using System.Text;

namespace PokerComTDD.Test.Interfaces
{
    public interface IAnalisadorDeVencedorComMaiorCartaService
    {
        string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador);
    }
}
