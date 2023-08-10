using Xadrez2.Entities;
using Xadrez2.Entities.Pieces;
using Xadrez2.Services;
Chessboard board = new Chessboard();
ConsoleColor turn = ConsoleColor.DarkRed;
string PrintMessage = null;

while (true)
{
    board.Printboard(null);
    if (PrintMessage != null)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(PrintMessage);
        Console.ForegroundColor = ConsoleColor.White;
        PrintMessage = null;
    }


    Console.ForegroundColor = turn;
    if (turn == ConsoleColor.DarkRed) Console.WriteLine("Player RED");
    else Console.WriteLine("Player BLUE");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("What piece do you wanna move?");

    Point piecePosition = CollectCMDInput.SelectPiece(board,turn);

    string skipped = board.MovePiece(piecePosition);

    if (skipped == "No")
    {
        if (turn == ConsoleColor.DarkRed) turn = ConsoleColor.DarkBlue;
        else turn = ConsoleColor.DarkRed;
    }
    else if (skipped == "NoMoves")
    { PrintMessage = "THERE ARE NO MOVES AVAILABLE FOR THIS CHESSPIECE"; }



}

board.Printboard(null);
