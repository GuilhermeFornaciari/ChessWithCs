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

    Point piecePosition = CollectCMDInput.SelectPiece(board,turn);

    bool skipped = board.MovePiece(piecePosition);

    if (!skipped)
    {
        if (turn == ConsoleColor.DarkRed) turn = ConsoleColor.DarkBlue;
        else turn = ConsoleColor.DarkRed;
    }



}

board.Printboard(null);
