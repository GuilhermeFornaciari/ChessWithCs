using Xadrez2.Entities;
using Xadrez2.Entities.Pieces;
using Xadrez2.Services;
Chessboard board = new Chessboard();
ConsoleColor turn = ConsoleColor.DarkRed;

while (true)
{
    board.Printboard(null);

    Console.ForegroundColor = turn;
    if (turn == ConsoleColor.DarkRed) Console.WriteLine("Player RED");
    else Console.WriteLine("Player BLUE");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("What piece do you wanna move?");



    Chesspiece piece = CollectCMDInput.SelectPiece(board,turn);

    Console.Clear();

    board.Printboard(piece.Move(board.board));

    Console.ReadLine();







    if (turn == ConsoleColor.DarkBlue) turn = ConsoleColor.DarkRed;
    if (turn == ConsoleColor.DarkRed) turn = ConsoleColor.DarkBlue;

}

board.Printboard(null);
