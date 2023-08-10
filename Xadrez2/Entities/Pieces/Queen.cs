using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

namespace Xadrez2.Entities.Pieces
{
    internal class Queen : Chesspiece
    {

        private int Direction { get; set; }
        public Queen(Point position, ConsoleColor color) : base(position, color) 
        {
            Moved = false;
            if (color == ConsoleColor.DarkRed) Direction = 1; else Direction = -1;
            Name = "Queen";
        }
        public override string ToString()
        {
            return "Q";
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

