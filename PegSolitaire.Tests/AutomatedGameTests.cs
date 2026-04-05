using NUnit.Framework;
using Peg_Solitaire_Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Tests
{
    [TestFixture]
    public class AutomatedGameTests
    {
        [Test]
        public void PlayStep_MakesValidMove()
        {
            var game = new AutomatedGame(7, "English");

            int before = game.Board.CountPegs();

            bool moved = game.PlayStep();

            int after = game.Board.CountPegs();

            Assert.That(moved, Is.True);
            Assert.That(after, Is.EqualTo(before - 1));
        }

        [Test]
        public void Solver_ReachesGameOver()
        {
            var game = new AutomatedGame(7, "English");

            int safetyCounter = 1000;

            while (!game.IsGameOver() && safetyCounter-- > 0)
            {
                game.PlayStep();
            }

            Assert.That(game.IsGameOver(), Is.True);
        }

        [Test]
        public void BacktrackingSolver_FindsSolution()
        {
            var board = new PegBoard(7);
            board.Initialize("English");

            var solver = new BacktrackingSolver();
            var solution = solver.Solve(board);

            Assert.That(solution, Is.Not.Null);
            Assert.That(solution.Count, Is.GreaterThan(0));
        }

        [Test]
        public void BacktrackingSolver_SolutionLeavesOnePeg()
        {
            var board = new PegBoard(7);
            board.Initialize("English");

            var solver = new BacktrackingSolver();
            var solution = solver.Solve(board);

            foreach (var move in solution)
            {
                board.MakeMove(move.from, move.to);
            }

            Assert.That(board.CountPegs(), Is.EqualTo(1));
        }
    }
}
