using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Peg_Solitaire_Game
{
    using System.Drawing;

    public class ManualGame : GameBase
    {
        private Point? selectedPeg = null;

        public ManualGame(int size, string type) : base(size, type) { }

        public ManualGame(PegBoard existingBoard) : base(existingBoard) { }

        public ManualGame(PegBoard board, List<GameMove> history) : base(board, history) { }

        public bool HandleClick(Point pos)
        {
            // First click: select peg
            if (selectedPeg == null)
            {
                if (board.Board[pos.X, pos.Y] == SlotState.Peg)
                {
                    selectedPeg = pos;
                }
                return false;
            }

            // Second click: attempt move
            Point from = selectedPeg.Value;
            Point to = pos;

            bool moved = TryMove(from, to);

            selectedPeg = null;
            return moved;
        }
    }
}
