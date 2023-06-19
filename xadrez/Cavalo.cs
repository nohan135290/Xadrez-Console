using System;
using xadres_Console.xadrez;
using xadres_Console.tabuleiro;

namespace xadres_Console.xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Pecas(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentoPossiveis()
        {
            bool [,] mat = new bool [Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 2);
            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
          
    }
}
