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

        public void Initialize(string boardType)
        {
            if (boardType == "English")
            {
                InitializeEnglish();
            }
            else if (boardType == "Hexagonal")
            {
                InitializeHex();
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

        private void InitializeHex()
        {
            int size = Board.GetLength(0);
            int center = size / 2;

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    int distance = Math.Abs(r - center);

                    int minCol = distance;
                    int maxCol = size - 1 - distance;

                    if (c >= minCol && c <= maxCol)
                    {
                        Board[r, c] = SlotState.Peg;
                    }
                    else
                    {
                        Board[r, c] = SlotState.Invalid;
                    }
                }
            }

            // Empty center
            Board[center, center] = SlotState.Empty;
        }

        public bool IsValidMove(Point from, Point to)
        {
            int size = Board.GetLength(0);

            // Bounds check
            if (from.X < 0 || from.X >= size ||
                from.Y < 0 || from.Y >= size ||
                to.X < 0 || to.X >= size ||
                to.Y < 0 || to.Y >= size)
            {
                return false;
            }

            // Must start on a peg
            if (Board[from.X, from.Y] != SlotState.Peg)
                return false;

            // Destination must be empty
            if (Board[to.X, to.Y] != SlotState.Empty)
                return false;

            int dx = to.X - from.X;
            int dy = to.Y - from.Y;

            bool validDirection =
                (Math.Abs(dx) == 2 && dy == 0) ||
                (Math.Abs(dy) == 2 && dx == 0) ||
                (dx == -2 && dy == 2) ||
                (dx == 2 && dy == -2);

            if (!validDirection)
                return false;

            Point mid = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

            /*// Find jumped peg
            int midR = (from.X + to.X) / 2;
            int midC = (from.Y + to.Y) / 2;
            */

            // Middle must contain a peg
            if (Board[mid.X, mid.Y] != SlotState.Peg)
                return false;

            return true;
        }

        public void MakeMove(Point from, Point to)
        {
            Point mid = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2);

            Board[from.X, from.Y] = SlotState.Empty;
            Board[mid.X, mid.Y] = SlotState.Empty;  // remove jumped peg
            Board[to.X, to.Y] = SlotState.Peg;

            /*int midR = (from.X + to.X) / 2;
            int midC = (from.Y + to.Y) / 2;

            // Move peg
            Board[to.X, to.Y] = SlotState.Peg;

            // Clear old positions
            Board[from.X, from.Y] = SlotState.Empty;
            Board[midR, midC] = SlotState.Empty;*/
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
                        new Point(r - 2, c), //up
                        new Point(r + 2, c), //down
                        new Point(r, c - 2), //left
                        new Point(r, c + 2), //right
                        new Point(r - 2, r + 2), //up-right
                        new Point(r + 2, c - 2) //down-left
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

        public PegBoard Clone()
        {
            int size = Board.GetLength(0);
            PegBoard copy = new PegBoard(size);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    copy.Board[r, c] = this.Board[r, c];
                }
            }

            return copy;
        }

        public List<(Point from, Point to)> GetAllValidMoves()
        {
            var moves = new List<(Point, Point)>();
            int size = Board.GetLength(0);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (Board[r, c] != SlotState.Peg)
                        continue;

                    Point from = new Point(r, c);

                    Point[] directions =
                    {
                        new Point(r - 2, c), //up
                        new Point(r + 2, c), //down
                        new Point(r, c - 2), //left
                        new Point(r, c + 2), //right
                        new Point(r - 2, r + 2), //up-right
                        new Point(r + 2, c - 2) //down-left
            };

                    foreach (var to in directions)
                    {
                        if (IsWithinBounds(to) && IsValidMove(from, to))
                        {
                            moves.Add((from, to));
                        }
                    }
                }
            }

            return moves;
        }
    }
}
