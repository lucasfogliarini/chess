using Chess;

Board board = new();
//falta:
//validar roque
//validar saltos
//usar notação algébrica simplificada: e4, nd6

string move;

while (true)
{
    board.Print();
    Console.Write("Jogada: ");
    move = Console.ReadLine();    

    if (move == "e") break;

    try
    {
        board.MovePiece(move);
        Console.Clear();
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
    }
}

