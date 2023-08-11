using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;
using Xadrez2.Services;

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
                    if ((ConvertP.PositiveOf(possibilityX)) == (ConvertP.PositiveOf(possibilityY))) continue;
                    movements.AddRange(LinearMovement(possibilityX, possibilityY, Chessboard,true));
                }
            }
            movements.Sort();
            return movements;
        }
    }
    }

