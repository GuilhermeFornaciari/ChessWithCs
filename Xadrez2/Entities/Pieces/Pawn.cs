using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

namespace Xadrez2.Entities.Pieces
{
    internal class Pawn : Chesspiece
    {
        public int Direction { get; set; }
        public Pawn(Point position, ConsoleColor color) : base(position, color) 
        {
            //int Direction;
            if (color == ConsoleColor.DarkRed) Direction = 1; else Direction = -1;
            XPossibilities = new int[3] { 1, -1, 0 };
            YPossibilities = new int[1] { Direction };
            Name = "Pawn";
            OnlyOne = true;
        }
        public override string ToString()
        {
            return "P";
        }
        internal override bool continueCondition(int possibilityX, int possibilityY)
        {
            return false;
        }
        internal override List<Point> Move(Chesspiece[,] chessboard) 
        {
            List < Point > movements = new List < Point >();

            int X = Position.X;
            int Y = Position.Y;

            if (X != 0 &&
                chessboard[X - 1, Y + (1 * Direction)] != null && 
                chessboard[X - 1, Y + (1 * Direction)].IsEnemy(this))
            {
                movements.Add(new Point(X-1, Y + (1 * Direction)));
            }

            if (X != 7 &&
                chessboard[X + 1, Y + (1 * Direction)] != null &&
                chessboard[X + 1, Y + (1 * Direction)].IsEnemy(this))
            {
                movements.Add(new Point(X + 1, Y + (1 * Direction)));
            }

            if (chessboard[Position.X,Position.Y+ (1 * Direction)] == null)
            {
                movements.Add(new Point(X, Y + (1 * Direction)));
                if (!Moved && chessboard[Position.X, Position.Y + (2 * Direction)] == null)
                    movements.Add(new Point(X, Y + (2 * Direction)));
            }
            movements.Sort();
            return movements;
        }



    }

    }

