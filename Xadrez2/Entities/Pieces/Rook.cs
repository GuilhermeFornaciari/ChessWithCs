using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

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

        private List<Point> searchForMovements(string MovementPattern, Chesspiece[,] Chessboard)
            {



            List<Point> movements = new List<Point>();
            
            return movements;
            }

        public override List<Point> Move(Chesspiece[,] Chessboard)
        {
            List< Point > movements = new List < Point >();

            int X = Position.X;
            int Y = Position.Y;

            string[] MovementPatterns = new string[4] { "X1", "X-1", "Y1", "Y-1" };
            // MovementPattern is the direction of the search, and in which variable (X or Y),
            // the first letter represents the axle ex: X or Y, and the rest represents the  direction, for example:
            // X-1 = Search for all the possible moves on the left of the rook;
            // Y-1 = Search for all the possible moves on the bottom of the rook;

            foreach (var movementPattern in MovementPatterns)
            {
                Point square = Position;

                string Axle = movementPattern.Substring(0, 1);
                int direction = int.Parse(movementPattern.Substring(1));

                if (Axle == "X") square.X += direction;
                else square.Y += direction;

                while (square.X <= 7 && square.X >= 0 &&
                       square.Y <= 7 && square.Y >= 0
                    ) 
                {


                    Console.WriteLine(square);
                    if (Chessboard[square.X, square.Y] == null)
                        movements.Add(square);
                    else if (Chessboard[square.X, square.Y].IsEnemy(this))
                    {
                        movements.Add(square);
                        break;
                    }
                    else break;
                    if (Axle == "X") square.X += direction;
                    else square.Y += direction;
                }
            }

            movements.Sort();

            return movements;
        }



    }

    }

