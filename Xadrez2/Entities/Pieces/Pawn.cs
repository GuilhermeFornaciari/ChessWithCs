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

        private int Direction { get; set; }
        public Pawn(Point position, ConsoleColor color) : base(position, color) 
        {
            Moved = false;
            if (color == ConsoleColor.DarkBlue) Direction = 1; else Direction = -1;
            Name = "Pawn";
        }
        public override string ToString()
        {
            return "P";
        }

        public override List<Point> Move(Chesspiece[,] Chessboard)
        {
            List < Point > movements = new List < Point >();

            int X = Position.X;
            int Y = Position.Y;

            if (X != 0 &&
                Chessboard[X - 1, Y + 1] != null && 
                Chessboard[X - 1, Y + 1].IsEnemy(this))
            {
                movements.Add(new Point(X-1, Y + 1));
            }

            if (X != 7 &&
                Chessboard[X + 1, Y + 1] != null &&
                Chessboard[X + 1, Y + 1].IsEnemy(this))
            {
                movements.Add(new Point(X + 1, Y + 1));
            }

            if (Chessboard[Position.X,Position.Y+1] == null)
            {
                movements.Add(new Point(X, Y + 1));
                if (!Moved && Chessboard[Position.X, Position.Y + 2] == null)
                    movements.Add(new Point(X, Y + 2));
            }
            movements.Sort();

            Console.WriteLine("Posição do peão: " + Position );
            foreach (Point p in movements) Console.Write(p + ",");
            Console.WriteLine();

            return movements;
        }



    }

    }

