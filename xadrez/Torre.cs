using System;
using xadres_Console.tabuleiro;
using xadres_Console.xadrez;

namespace xadres_Console.xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Pecas(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool [,] MovimentoPossiveis()
        {
            bool [,] math = new bool [Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna);
            while(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
                if(Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Baixo
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Direita
            pos.DefinirValor(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Esquerda
            pos.DefinirValor(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
                if (Tab.Pecas(pos) != null && Tab.Pecas(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return math;
        }
    }
}
