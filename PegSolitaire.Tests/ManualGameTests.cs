using Peg_Solitaire_Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NUnit.Framework;

namespace PegSolitaire.Tests
{
    [TestFixture]
    public class ManualGameTests
    {
        [Test]
        public void HandleClick_FirstClick_SelectsPeg_NoMoveMade()
        {
            var game = new ManualGame(7, "English");

            bool moved = game.HandleClick(new Point(3, 1)); // valid peg

            Assert.That(moved, Is.False);
        }

        [Test]
        public void HandleClick_ValidMove_UpdatesBoard()
        {
            var game = new ManualGame(7, "English");

            // Select peg
            game.HandleClick(new Point(3, 1));

            // Move to center
            bool moved = game.HandleClick(new Point(3, 3));

            Assert.That(moved, Is.True);
            Assert.That(game.Board.Board[3, 3], Is.EqualTo(SlotState.Peg));
            Assert.That(game.Board.Board[3, 2], Is.EqualTo(SlotState.Empty));
        }

        [Test]
        public void HandleClick_InvalidMove_ReturnsFalse()
        {
            var game = new ManualGame(7, "English");

            game.HandleClick(new Point(0, 0)); // invalid or empty

            bool moved = game.HandleClick(new Point(0, 2));

            Assert.That(moved, Is.False);
        }
    }
}




