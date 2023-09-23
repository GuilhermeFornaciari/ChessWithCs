using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Services;

namespace Xadrez2.Entities
{
    internal abstract class Chesspiece
    {
        internal bool Moved { get; set; }
        public ConsoleColor Color { get; set; }
        public string Name { get; set; }
        internal int[] XPossibilities { get; set; }
        internal int[] YPossibilities { get; set; }
        public Chesspiece(Point position, ConsoleColor color)
        {
            Position = position;
            Color = color;
            Moved = false;
        }

        public bool IsEnemy(Chesspiece piece)
        {
            if (piece.Color != this.Color) return true;
            else return false;
        }

        private Point _position;

        public Point Position
        {
            get { return _position; }
            set { 
                _position.X = value.X;
                _position.Y = value.Y;
            }
        }
        internal abstract bool continueCondition(int possibilityX, int possibilityY);
        internal virtual List<Point> Move(Chesspiece[,] chessboard)
        {
            List<Point> movements = new List<Point>();
            foreach (int possibilityX in XPossibilities)
            {
                foreach (int possibilityY in YPossibilities)
                {
                    if (continueCondition(possibilityX, possibilityY)) continue;

                    Point square = new Point(Position.X + possibilityX, Position.Y + possibilityY);
                    while (square.X <= 7 && square.X >= 0 &&
                           square.Y <= 7 && square.Y >= 0)
                    {
                        if (chessboard[square.X, square.Y] != null)
                        {
                            if (chessboard[square.X, square.Y].IsEnemy(this)) movements.Add(square);
                            break;
                        }
                        movements.Add(square);
                        square.X += possibilityX;
                        square.Y += possibilityY;

                        if (OnlyOne) break;
                    }
                }
            }
            movements.Sort();
            return movements;
        }
        private bool _onlyOne;
        [DefaultValue(false)]
        public bool OnlyOne
        {
            get { return _onlyOne; }
            set { _onlyOne = value; }
        }
    }
}
