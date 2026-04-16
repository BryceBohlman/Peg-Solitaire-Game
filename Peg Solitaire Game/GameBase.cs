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
        protected List<GameMove> moveHistory;

        public PegBoard Board => board;
        public IReadOnlyList<GameMove> MoveHistory => moveHistory.AsReadOnly();

        public GameBase(int size, string type)
        {
            board = new PegBoard(size);
            board.Initialize(type);
            moveHistory = new List<GameMove>();
        }

        protected GameBase(PegBoard existingBoard)
        {
            board = existingBoard ?? throw new ArgumentNullException(nameof(existingBoard));
            moveHistory = new List<GameMove>();

        }

        protected GameBase(PegBoard existingBoard, List<GameMove> existingHistory)
        {
            board = existingBoard;
            moveHistory = existingHistory ?? new List<GameMove>();
        }

        public bool TryMove(Point from, Point to)
        {
            if (board.IsValidMove(from, to))
            {
                board.MakeMove(from, to);
                moveHistory.Add(new GameMove(from, to));
                return true;
            }

            return false;
        }

        public bool IsGameOver()
        {
            return board.CountPegs() == 1 || !board.HasAnyValidMoves();
        }

        public void SaveToFile(string filePath)
        {
            File.WriteAllLines(filePath, board.ToTextLines());
        }

        public void SaveReplayToFile(string filePath, string modeName)
        {
            var lines = new List<string>
            {
                $"Size={board.Size}",
                $"Type={board.BoardType}",
                $"Mode={modeName}",
                $"MovesCount={moveHistory.Count}",
                "Moves:"
            };

            foreach (GameMove move in moveHistory)
            {
                lines.Add(move.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }

        public void Shuffle(int moves = 50)
        {
            Random rand = new Random();

            for (int i = 0; i < moves; i++)
            {
                var validMoves = board.GetAllValidMoves();

                if (validMoves.Count == 0)
                    break;

                var move = validMoves[rand.Next(validMoves.Count)];

                TryMove(move.from, move.to);
            }
        }
    }
}
