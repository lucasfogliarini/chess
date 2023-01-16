using Chess;

Board board = new();

board.Print();

board.MovePiece("e2e4");
board.MovePiece("c7c5");
board.MovePiece("g1f3");

Console.Clear();

board.Print();