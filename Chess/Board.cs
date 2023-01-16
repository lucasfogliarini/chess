using Chess.Pieces;
using System.Linq.Expressions;

namespace Chess
{
    // Class to represent the chess board
    class Board
    {
        // Two-dimensional array to hold the pieces
        public Piece[,] Pieces { get; private set; } = new Piece[8, 8];

        // Constructor to set up the board
        public Board() : this("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
        }

        // Constructor to set up the board using FEN
        public Board(string FEN)
        {
            int y = 0;
            int x = 0;
            foreach (char position in FEN)
            {
                if (position == ' ')
                {
                    break;
                }
                else if (char.IsNumber(position))
                {
                    int nextPosition = position - '0';
                    x += nextPosition;
                }
                else if (position == '/')
                {
                    y++;
                    x = 0;
                }
                else
                {
                    Pieces[y, x] = Piece.Generate(position);
                    x++;
                }
            }
        }

        // Method to print the board to the console
        public void Print()
        {
            // Print the column labels
            Console.Write("  ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(" " + (char)('a' + x));
            }
            Console.WriteLine();

            // Print the rows
            for (int y = 0; y < 8; y++)
            {
                // Print the row label
                Console.Write((8 - y) + " ");

                // Print the pieces
                for (int x = 0; x < 8; x++)
                {
                    if (Pieces[y, x] == null)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(Pieces[y, x].Symbol);
                    }
                    Console.Write(" ");
                }

                // Print the row label again
                Console.Write((8 - y));

                Console.WriteLine();
            }

            // Print the column labels
            Console.Write("  ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(" " + (char)('a' + x));
            }
            Console.WriteLine();
        }


        // Method to make a move
        public void MovePiece(int startX, int startY, int endX, int endY)
        {
            // Make sure the start and end positions are on the board
            if (startX < 0 || startX > 7 || startY < 0 || startY > 7 || endX < 0 || endX > 7 || endY < 0 || endY > 7)
            {
                Console.WriteLine("Invalid move.");
                return;
            }

            // Make sure there is a piece at the start position
            if (Pieces[startY, startX] == null)
            {
                Console.WriteLine("There is no piece at the start position.");
                return;
            }

            // Check if the move is valid for the piece
            if (!Pieces[startY, startX].IsValidMove(startX, startY, endX, endY))
            {
                Console.WriteLine("Invalid move for that piece.");
                return;
            }

            // Make the move
            Pieces[endY, endX] = Pieces[startY, startX];
            Pieces[startY, startX] = null;
        }

        // Method to make a move
        public void MovePiece(string move)
        {
            // Parse the move string into start and end coordinates
            int startX = move[0] - 'a';
            int startY = 8 - (move[1] - '0');
            int endX = move[2] - 'a';
            int endY = 8 - (move[3] - '0');

            MovePiece(startX, startY, endX, endY);
        }

    }
}
