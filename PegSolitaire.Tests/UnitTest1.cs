using Peg_Solitaire_Game;
using NUnit.Framework;
using System.Drawing;

namespace PegSolitaire.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Initialize_EnglishBoard_HasCorrectCenterEmpty()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            Assert.AreEqual(SlotState.Empty, board.Board[3, 3]);
        }

        [Test]
        public void Initialize_EnglishBoard_CornersAreInvalid()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            Assert.AreEqual(SlotState.Invalid, board.Board[0, 0]);
            Assert.AreEqual(SlotState.Invalid, board.Board[0, 1]);
            Assert.AreEqual(SlotState.Invalid, board.Board[1, 0]);
        }

        [Test]
        public void NewGame_StartsWithCorrectPegCount()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            int pegCount = board.CountPegs();

            Assert.AreEqual(32, pegCount); // standard English board
        }

        [Test]
        public void IsValidMove_ValidJump_ReturnsTrue()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            Point from = new Point(3, 1);
            Point to = new Point(3, 3);

            Assert.IsTrue(board.IsValidMove(from, to));
        }

        [Test]
        public void IsValidMove_InvalidMove_ReturnsFalse()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            Point from = new Point(0, 0); // invalid slot

            Point to = new Point(0, 2);

            Assert.IsFalse(board.IsValidMove(from, to));
        }

        [Test]
        public void MakeMove_RemovesJumpedPeg()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            Point from = new Point(3, 1);
            Point to = new Point(3, 3);

            board.MakeMove(from, to);

            Assert.AreEqual(SlotState.Empty, board.Board[3, 1]); // source cleared
            Assert.AreEqual(SlotState.Empty, board.Board[3, 2]); // jumped removed
            Assert.AreEqual(SlotState.Peg, board.Board[3, 3]); // destination filled
        }

        [Test]
        public void CountPegs_OnePegLeft_ReturnsOne()
        {
            PegBoard board = new PegBoard(7);

            // manually set board
            board.Board = new SlotState[7, 7];
            board.Board[3, 3] = SlotState.Peg;

            Assert.AreEqual(1, board.CountPegs());
        }

        [Test]
        public void HasAnyValidMoves_NoMoves_ReturnsFalse()
        {
            PegBoard board = new PegBoard(7);

            // Fill with isolated pegs (no jumps possible)
            for (int r = 0; r < 7; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    board.Board[r, c] = SlotState.Empty;
                }
            }

            board.Board[3, 3] = SlotState.Peg;

            Assert.IsFalse(board.HasAnyValidMoves());
        }
    }
}
