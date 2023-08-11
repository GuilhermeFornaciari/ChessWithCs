using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;
using Xadrez2.Services;

namespace Xadrez2.Entities.Pieces
{
    internal class Rook : Chesspiece
    {

        public Rook(Point position, ConsoleColor color) : base(position, color)
        {
            Moved = false;
            Name = "Rook";
        }
        public override string ToString()
        {
            return "R";
        }



        public override List<Point> Move(Chesspiece[,] Chessboard)
        {
            List<Point> movements = new List<Point>();

            int X = Position.X;
            int Y = Position.Y;


            int[] Xpossibilities = new int[] { 1, -1, 0 };
            int[] Ypossibilities = new int[] { 1, -1, 0 };

            foreach (int possibilityX in Xpossibilities)
            {
                foreach (int possibilityY in Ypossibilities)
                {
                    if (ConvertP.PositiveOf(possibilityX) + ConvertP.PositiveOf(possibilityY) > 1) continue;
                    movements.AddRange(LinearMovement(possibilityX, possibilityY, Chessboard,null));
                }
            }
            movements.Sort();
            return movements;
        }



    }

    }

