using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

namespace Xadrez2.Entities.Pieces
{
    internal class Bishop : Chesspiece
    {

        public Bishop(Point position, ConsoleColor color) : base(position, color) 
        {
            Moved = false;
            Name = "Bishop";
        }
        public override string ToString()
        {
            return "B";
        }

        public override List<Point> Move(Chesspiece[,] Chessboard)
        {
            List < Point > movements = new List < Point >();

            int X = Position.X;
            int Y = Position.Y;

            movements.Sort();
            return movements;
        }



    }

    }

