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
            else if (piece.Color != turn) Console.WriteLine($"You selected the enemy {piece.Name}");
            else break;
        } 

        catch (Exception e)
        {
            Console.WriteLine("The position informed is invalid, please inform the piece wanted in the format: A1");
        }
    }
    Console.Clear();

    board.Printboard(piece.Move(board.board));

    Console.ReadLine();







    if (turn == ConsoleColor.DarkBlue) turn = ConsoleColor.DarkRed;
    if (turn == ConsoleColor.DarkRed) turn = ConsoleColor.DarkBlue;

}

board.Printboard(null);
