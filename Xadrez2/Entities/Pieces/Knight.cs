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

        public Knight(Point position, ConsoleColor color) : base(position, color) 
        {
            Moved = false;
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

            int[] Xpossibilities = new int[] {2,-2,1,-1};
            int[] Ypossibilities = new int[] {2,-2,1,-1};

            foreach (int possibilityX in Xpossibilities)
            {
                foreach (int possibilityY in Ypossibilities)
                {
                    if ((possibilityX > 0 ? possibilityX : -possibilityX) == (possibilityY > 0 ? possibilityY : -possibilityY)) continue;
                    if ((X + possibilityX) < 0 || (X + possibilityX) > 7) continue;
                    if ((Y + possibilityY) < 0 || (Y + possibilityY) > 7) continue;

                    Chesspiece square = Chessboard[X + possibilityX, Y + possibilityY];
                    if (square == null || 
                        Chessboard[X + possibilityX, Y + possibilityY].IsEnemy(this)) 
                        movements.Add(new Point(X + possibilityX, Y + possibilityY));
                }
            }
            movements.Sort();
            return movements;
        }
    }
    }

