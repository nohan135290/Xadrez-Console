using System;
using xadres_Console.tabuleiro;

namespace xadres_Console.tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg)
        {
        }
    }
}
