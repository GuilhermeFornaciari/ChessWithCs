using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

namespace Xadrez2.Entities.Pieces
{
    internal class King : Chesspiece
    {
        public King(Point position, ConsoleColor color) : base(position, color) 
        {
            Moved = false;
            Name = "King";
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

            movements.Sort();
            return movements;
        }



    }

    }

