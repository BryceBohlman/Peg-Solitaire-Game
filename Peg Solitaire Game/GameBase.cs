using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Peg_Solitaire_Game
{
    //Parent class of ManualGame and AutomatedGame classes
    using System.Drawing;

    public abstract class GameBase
    {
        protected PegBoard board;

        public PegBoard Board => board;

        public GameBase(int size, string type)
        {
            board = new PegBoard(size);
            board.Initialize(type);
        }

        public bool TryMove(Point from, Point to)
        {
            if (board.IsValidMove(from, to))
            {
                board.MakeMove(from, to);
                return true;
            }

            return false;
        }

        public bool IsGameOver()
        {
            return board.CountPegs() == 1 || !board.HasAnyValidMoves();
        }
    }
}
