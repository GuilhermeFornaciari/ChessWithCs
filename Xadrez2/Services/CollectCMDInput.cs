using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;

namespace Xadrez2.Services
{
    internal static class CollectCMDInput
    {
        public static string MovePiece(List<Point> AttackPoints)
        {
            while (true)
            {
                Console.WriteLine("Available moves:");
                List<string> AvailableMoves = new List<string>();
                foreach (Point attackPoint in AttackPoints)
                {
                    string pointChessFormat = ConvertP.PointToStr(attackPoint);
                    AvailableMoves.Add(pointChessFormat);
                    Console.Write(pointChessFormat + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Type nothing to select another piece");
                string cmdInput = Console.ReadLine().ToUpper();
                if (AvailableMoves.Find((el) => el == cmdInput) != null)
                    return cmdInput;
                else if (cmdInput == "") return cmdInput;
                
                else Console.WriteLine("Invalid input, please select one of the options below: ");
            }

            
        }
        public static Point SelectPiece(Chessboard board,ConsoleColor color)
        {
            Chesspiece piece;
            while (true)
            {
                try
                {
                    string cmdAnswer = Console.ReadLine();
                    cmdAnswer = cmdAnswer.ToUpper();
                    if (cmdAnswer == "") throw new ArgumentException();

                    Point position = ConvertP.StrToPoint(cmdAnswer);
                    piece = board.board[position.X, position.Y];

                    if (piece == null) throw new ArgumentNullException();
                    else if (piece.Color != color) throw new InvalidDataException();

                    return piece.Position;
                }

                catch (ArgumentNullException)
                {
                    Console.WriteLine("You selected a empty space, please select a valid space (A to H; 1 to 8)");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please, inform us the piece you wanna move");
                }
                catch (InvalidDataException)
                {
                    Console.WriteLine($"You selected the enemy piece");
                }
                catch (Exception e)
                {
                    Console.WriteLine("The position informed is invalid, please inform the piece wanted in the format (A-H) (1-8) Ex:  A1");
                }
            }

        }
    }
}
