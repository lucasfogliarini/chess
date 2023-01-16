using Chess.Pieces;
using System.Linq.Expressions;

namespace Chess
{
    // Class to represent the chess board
    class Board
    {
        // Two-dimensional array to hold the pieces
        public Piece[,] Pieces { get; private set; } = new Piece[8, 8];

        public bool WhiteTurn { get; private set; }
        public string Turn { get { return WhiteTurn ? "Brancas" : "Pretas"; } }

        // Constructor to set up the board
        public Board() : this("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
        }

        // Constructor to set up the board using FEN
        public Board(string FEN)
        {
            var fenSplitted = FEN.Split(' ');
            WhiteTurn = fenSplitted[1] == "w";

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
            Console.Title = $"{Turn} jogam";
            Console.BackgroundColor = WhiteTurn ? ConsoleColor.White : ConsoleColor.Black;
            Console.ForegroundColor = WhiteTurn ? ConsoleColor.Black : ConsoleColor.White;

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
            Console.WriteLine();
        }

        // Method to make a move
        public void MovePiece(int startX, int startY, int endX, int endY)
        {
            var startPiece = Pieces[startY, startX];

            // Make sure the start and end positions are on the board
            if (startX < 0 || startX > 7 || startY < 0 || startY > 7 || endX < 0 || endX > 7 || endY < 0 || endY > 7)
            {
                throw new Exception("Movimento inválido, essas posições estão fora do alcance do tabuleiro.");
            }

            if (startPiece == null)
            {
                throw new Exception("Movimento inválido, não existe peça na posição inicial informada.");
            }

            // Make sure there is a piece at the start position
            if (startPiece.IsWhite && !WhiteTurn || !startPiece.IsWhite && WhiteTurn)
            {
                throw new Exception($"Movimento inválido, é a vez das {Turn}.");
            }

            // Check if the move is valid for the piece
            if (!Pieces[startY, startX].IsValidMove(this, startX, startY, endX, endY))
            {
                throw new Exception("Movimento inválido para essa peça.");
            }

            // Make the move
            WhiteTurn = !startPiece.IsWhite;
            Pieces[endY, endX] = Pieces[startY, startX];
            Pieces[startY, startX] = null;

            Print();
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
