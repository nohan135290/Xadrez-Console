using System;
using xadres_Console.tabuleiro;

namespace xadres_Console.tabuleiro
{
     abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.Posicao = null;
            this.Tab = tab;
            this.Cor = cor;
            this.QteMovimentos = 0;
        }

        public void IncrementarQteMovimento()
        {
            QteMovimentos++;
        }

        public void DecrementarQteMovimento()
        {
            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool [,] mat = MovimentoPossiveis();
            for (int i=0; i<Tab.Linhas; i++)
            {
                for(int j=0; j<Tab.Colunas; j++)
                {
                    if(mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentoPossiveis() [pos.Linha, pos.Coluna];
        }

        public abstract bool [,] MovimentoPossiveis();
    }
}
