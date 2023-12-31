﻿using System;

using xadres_Console.xadrez;
using xadres_Console.tabuleiro;

namespace xadres_Console.xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Pecas(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Pecas(pos) == null;
        }

        public override bool[,] MovimentoPossiveis()
        {
            bool [,] mat = new bool [Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Branca)
            {
                pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna);
                if(Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValor(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }

                //#JogadaEspecial en passant
                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Pecas(esquerda) == Partida.VulneravelEnPassant){
                        mat [esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Pecas(direita) == Partida.VulneravelEnPassant)
                    {
                        mat [direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValor(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat [pos.Linha, pos.Coluna] = true;
                }

                //#JogadaEspecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Pecas(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat [esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Pecas(direita) == Partida.VulneravelEnPassant)
                    {
                        mat [direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;          
        }
    }
}
