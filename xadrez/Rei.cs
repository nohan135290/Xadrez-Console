using System;
using xadres_Console.tabuleiro;
using xadres_Console.xadrez;

namespace xadres_Console.xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Pecas(pos);
            return p == null || p.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.Pecas(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }

        public override bool [,] MovimentoPossiveis()
        {
            bool [,] math = new bool [Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Acíma
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna);
            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // Ne
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // Direita
            pos.DefinirValor(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // Su
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // Baixo
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // So
            pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // Esquerda
            pos.DefinirValor(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            // No
            pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                math [pos.Linha, pos.Coluna] = true;
            }

            //#JogadaEspecial Roque
            if(QteMovimentos == 0 && !Partida.Xeque)
            {
                //Rogue pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tab.Pecas(p1)==null && Tab.Pecas(p2) == null)
                    {
                        math [Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                //Roque Grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Pecas(p1) == null && Tab.Pecas(p2) == null && Tab.Pecas(p3) == null)
                    {
                        math [Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }


            return math;
        }
    }
}
