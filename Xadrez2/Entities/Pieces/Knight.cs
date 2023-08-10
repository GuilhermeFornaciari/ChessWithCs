using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

namespace Xadrez2.Entities.Pieces
{
    internal class Knight : Chesspiece
    {

        private int Direction { get; set; }
        public Knight(Point position, ConsoleColor color) : base(position, color) 
        {
            Moved = false;
            if (color == ConsoleColor.DarkRed) Direction = 1; else Direction = -1;
            Name = "Knight";
        }
        public override string ToString()
        {
            return "K";
        }

        public override List<Point> Move(Chesspiece[,] Chessboard)
        {
            List < Point > movements = new List < Point >();

            int X = Position.X;
            int Y = Position.Y;

            if (X != 0 &&
                Chessboard[X - 1, Y + (1 * Direction)] != null && 
                Chessboard[X - 1, Y + (1 * Direction)].IsEnemy(this))
            {
                movements.Add(new Point(X-1, Y + (1 * Direction)));
            }

            if (X != 7 &&
                Chessboard[X + 1, Y + (1 * Direction)] != null &&
                Chessboard[X + 1, Y + (1 * Direction)].IsEnemy(this))
            {
                movements.Add(new Point(X + 1, Y + (1 * Direction)));
            }

            if (Chessboard[Position.X,Position.Y+ (1 * Direction)] == null)
            {
                movements.Add(new Point(X, Y + (1 * Direction)));
                if (!Moved && Chessboard[Position.X, Position.Y + (2 * Direction)] == null)
                    movements.Add(new Point(X, Y + (2 * Direction)));
            }
            movements.Sort();
            return movements;
        }



    }

    }

