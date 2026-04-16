using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Peg_Solitaire_Game
{
    public struct GameMove
    {
        public Point From { get; }
        public Point To { get; }

        public GameMove(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"{From.X},{From.Y}->{To.X},{To.Y}";
        }

        public static GameMove Parse(string text)
        {
            string[] halves = text.Split("->");
            if (halves.Length != 2)
                throw new FormatException("Invalid move format.");

            string[] fromParts = halves[0].Split(',');
            string[] toParts = halves[1].Split(',');

            if (fromParts.Length != 2 || toParts.Length != 2)
                throw new FormatException("Invalid move coordinates.");

            Point from = new Point(int.Parse(fromParts[0]), int.Parse(fromParts[1]));
            Point to = new Point(int.Parse(toParts[0]), int.Parse(toParts[1]));

            return new GameMove(from, to);
        }
    }
}
