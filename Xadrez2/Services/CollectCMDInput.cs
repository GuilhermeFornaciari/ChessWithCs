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
        public static Chesspiece SelectPiece(Chessboard board,ConsoleColor color)
        {
            Chesspiece piece;
            while (true)
            {

                try
                {
                    string cmdAnswer = Console.ReadLine();
                    if (cmdAnswer == "") Console.WriteLine("Please, inform us the piece you wanna move");

                    Point position = ConvertP.StrToPoint(cmdAnswer);
                    piece = board.board[position.X, position.Y];

                    if (piece == null) Console.WriteLine("You selected a empty space, please select a valid space (A to H; 1 to 8)");
                    else if (piece.Color != color) Console.WriteLine($"You selected the enemy {piece.Name}");
                    else break;
                }

                catch (Exception e)
                {
                    Console.WriteLine("The position informed is invalid, please inform the piece wanted in the format: A1");
                }
            }
            return piece;
        }
    }
}
