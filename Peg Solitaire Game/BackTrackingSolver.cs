using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Peg_Solitaire_Game
{
    public class BacktrackingSolver
    {
        public List<(Point from, Point to)> Solve(PegBoard board)
        {
            return SolveRecursive(board);
        }

        private List<(Point from, Point to)> SolveRecursive(PegBoard board)
        {
            // Win condition
            if (board.CountPegs() == 1)
            {
                return new List<(Point, Point)>();
            }

            var moves = board.GetAllValidMoves();

            // Dead end
            if (moves.Count == 0)
            {
                return null;
            }

            foreach (var move in moves)
            {
                // Clone board
                PegBoard copy = board.Clone();

                // Apply move
                copy.MakeMove(move.from, move.to);

                // Recurse
                var result = SolveRecursive(copy);

                if (result != null)
                {
                    result.Insert(0, move);
                    return result;
                }
            }

            return null;
        }
    }
}
