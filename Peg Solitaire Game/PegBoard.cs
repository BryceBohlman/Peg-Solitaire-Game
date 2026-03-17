using System;
using System.Collections.Generic;
using System.Text;

namespace Peg_Solitaire_Game
{
    public enum SlotState
    {
        Invalid,
        Empty,
        Peg
    }

    public class PegBoard
    {
        public SlotState[,] Board;

        public PegBoard(int size)
        {
            Board = new SlotState[size, size];
        }

        public bool IsValidMove(Point from, Point to)
        {
            // Must start on a peg
            if (Board[from.X, from.Y] != SlotState.Peg)
                return false;

            // Destination must be empty
            if (Board[to.X, to.Y] != SlotState.Empty)
                return false;

            int dr = to.X - from.X;
            int dc = to.Y - from.Y;

            // Must move exactly 2 spaces in one direction
            if (!((Math.Abs(dr) == 2 && dc == 0) ||
                  (Math.Abs(dc) == 2 && dr == 0)))
                return false;

            // Find jumped peg
            int midR = (from.X + to.X) / 2;
            int midC = (from.Y + to.Y) / 2;

            // Middle must contain a peg
            if (Board[midR, midC] != SlotState.Peg)
                return false;

            return true;
        }

        public void MakeMove(Point from, Point to)
        {
            int midR = (from.X + to.X) / 2;
            int midC = (from.Y + to.Y) / 2;

            // Move peg
            Board[to.X, to.Y] = SlotState.Peg;

            // Clear old positions
            Board[from.X, from.Y] = SlotState.Empty;
            Board[midR, midC] = SlotState.Empty;
        }

        public void Initialize(string boardType)
        {
            if (boardType == "English")
            {
                InitializeEnglish();
            }
        }

        private void InitializeEnglish()
        {
            int size = Board.GetLength(0);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    // Mark everything invalid first
                    Board[r, c] = SlotState.Invalid;

                    // Middle rows/columns form the cross
                    if ((r >= 2 && r <= 4) || (c >= 2 && c <= 4))
                    {
                        Board[r, c] = SlotState.Peg;
                    }
                }
            }

            // Center starts empty
            Board[3, 3] = SlotState.Empty;
        }

        public int CountPegs()
        {
            int count = 0;

            for (int r = 0; r < Board.GetLength(0); r++)
            {
                for (int c = 0; c < Board.GetLength(1); c++)
                {
                    if (Board[r, c] == SlotState.Peg)
                        count++;
                }
            }

            return count;
        }

        public bool HasAnyValidMoves()
        {
            int size = Board.GetLength(0);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (Board[r, c] != SlotState.Peg)
                        continue;

                    Point from = new Point(r, c);

                    // Try all 4 directions
                    Point[] directions =
                    {
                        new Point(r - 2, c),
                        new Point(r + 2, c),
                        new Point(r, c - 2),
                        new Point(r, c + 2)
            };

                    foreach (var to in directions)
                    {
                        if (IsWithinBounds(to) && IsValidMove(from, to))
                            return true;
                    }
                }
            }

            return false;
        }

        private bool IsWithinBounds(Point p)
        {
            int size = Board.GetLength(0);

            return p.X >= 0 && p.X < size &&
                   p.Y >= 0 && p.Y < size;
        }
    }

}
