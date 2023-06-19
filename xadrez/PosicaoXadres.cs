using System;
using xadres_Console.xadrez;
using xadres_Console.tabuleiro;

namespace xadres_Console.xadrez
{
    class PosicaoXadres
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadres(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
