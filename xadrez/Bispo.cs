using System;
using xadres_Console.tabuleiro;

namespace xadres_Console.xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "B";
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

            //NO
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);
            while(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
                if(Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValor(pos.Linha - 1, pos.Coluna + 1);
            }

            // NE
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValor(pos.Linha - 1, pos.Coluna + 1);
            }

            //SE
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValor(pos.Linha + 1, pos.Coluna + 1);
            }

            //SO
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat [pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValor(pos.Linha + 1, pos.Coluna + 1);
            }
            return mat;
        }
    }
}
