// Set up the board
using Chess;

Board board = new();

board.Print();

board.MovePiece(3, 1, 4, 3);

Console.WriteLine();
board.Print();