using Chess;

try
{
    Board board = new();

    board.MovePiece("e2e4");
    board.MovePiece("c7c5");
    board.MovePiece("g1f3");
    Console.Clear();
    board.Print();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
}

