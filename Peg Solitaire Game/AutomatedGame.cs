using System;
using System.Collections.Generic;
using System.Text;

namespace Peg_Solitaire_Game
{
    using System.Drawing;

    //!!!TODO: Autosolver takes exponential time, implement memoization
    public class AutomatedGame : GameBase
    {
        private List<(Point from, Point to)> solution;
        private int currentStep = 0;

        public AutomatedGame(int size, string type) : base(size, type) { }

        public bool PlayStep()
        {
            if (solution == null || currentStep >= solution.Count)
                return false;

            var move = solution[currentStep];
            board.MakeMove(move.from, move.to);

            currentStep++;
            return true;
        }

        private bool IsWithinBounds(Point p)
        {
            int size = board.Board.GetLength(0);

            return p.X >= 0 && p.X < size &&
                   p.Y >= 0 && p.Y < size;
        }

        private (Point from, Point to)? FindMove()
        {
            int size = board.Board.GetLength(0);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (board.Board[r, c] != SlotState.Peg)
                        continue;

                    Point from = new Point(r, c);

                    Point[] moves =
                    {
                        new Point(r - 2, c), //up
                        new Point(r + 2, c), //down
                        new Point(r, c - 2), //left
                        new Point(r, c + 2), //right
                        new Point(r - 2, r + 2), //up-right
                        new Point(r + 2, c - 2) //down-left
                };

                    foreach (var to in moves)
                    {
                        if (IsWithinBounds(to) && board.IsValidMove(from, to))
                            return (from, to);
                    }
                }
            }

            return null;
        }

        public void ComputeSolution()
        {
            var solver = new BacktrackingSolver();
            solution = solver.Solve(board.Clone());
            currentStep = 0;
        }
    }
}
