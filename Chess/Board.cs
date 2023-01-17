using Chess.Pieces;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Chess
{
    // Class to represent the chess board
    class Board
    {
        // Two-dimensional array to hold the pieces
        public Piece[,] Pieces { get; private set; } = new Piece[8, 8];
        public bool WhiteTurn { get; private set; }
        public string Turn { get { return WhiteTurn ? "Brancas" : "Pretas"; } }
        public string Castle { get; set; }

        // Constructor to set up the board
        public Board() : this("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
        }

        // Constructor to set up the board using FEN
        public Board(string FEN)
        {
            var fenSplitted = FEN.Split(' ');
            WhiteTurn = fenSplitted[1] == "w";
            Castle = fenSplitted[2];

            int y = 0;
            int x = 0;
            foreach (char symbol in FEN)
            {
                if (symbol == ' ')
                {
                    break;
                }
                else if (char.IsNumber(symbol))
                {
                    int nextPosition = symbol - '0';
                    x += nextPosition;
                }
                else if (symbol == '/')
                {
                    y++;
                    x = 0;
                }
                else
                {
                    Pieces[y, x] = Piece.Generate(symbol);
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
            var piece = Pieces[startY, startX];

            bool moveCastle = ValidateAndMoveCastle(piece, startX, endX);
            if (!moveCastle)
            {
                ValidateMove(piece, startX, startY, endX, endY);
            }

            // Make the move
            WhiteTurn = !piece.IsWhite;
            piece.InStartingPosition = false;
            Pieces[endY, endX] = piece;
            Pieces[startY, startX] = null;

            Print();
        }

        private void ValidateMove(Piece piece, int startX, int startY, int endX, int endY)
        {
            // Make sure the start and end positions are on the board
            if (startX < 0 || startX > 7 || startY < 0 || startY > 7 || endX < 0 || endX > 7 || endY < 0 || endY > 7)
            {
                throw new Exception("Movimento inválido, essas posições estão fora do alcance do tabuleiro.");
            }

            if (piece == null)
            {
                throw new Exception("Movimento inválido, não existe peça na posição inicial informada.");
            }

            // Make sure there is a piece at the start position
            if (piece.IsWhite && !WhiteTurn || !piece.IsWhite && WhiteTurn)
            {
                throw new Exception($"Movimento inválido, é a vez das {Turn}.");
            }

            // Check if the move is valid for the piece
            if (!piece.IsValidMove(this, startX, startY, endX, endY))
            {
                throw new Exception("Movimento inválido para essa peça.");
            }
        }

        private bool ValidateAndMoveCastle(Piece piece, int startX, int endX)
        {
            bool moveCastle = false;
            if (piece.InStartingPosition)
            {
                if (!string.IsNullOrEmpty(Castle))
                {
                    if (piece is Rook)
                    {
                        var sideCastle = SideCastle(piece.IsWhite, startX == 7);
                        Castle = Castle.Replace(sideCastle, "");
                    }
                    else if (piece is King)
                    {
                        bool kingSide = endX == 6;
                        if (kingSide || endX == 2)
                        {
                            var sideCastle = SideCastle(piece.IsWhite, kingSide);
                            if (Castle.Contains(sideCastle))
                            {
                                CastleRook(piece.IsWhite, kingSide);
                                moveCastle = true;
                            }
                            else
                            {
                                return moveCastle;
                            }
                        }

                        var possibleCastle = piece.IsWhite ? "[KQ]" : "[kq]";
                        Regex regex = new(possibleCastle);
                        Castle = regex.Replace(Castle, "");
                    }
                }
            }
            return moveCastle;
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

        private string SideCastle(bool isWhite, bool kingSide)
        {
            var sideCastle = kingSide ? "k" : "q";
            if (isWhite)
                sideCastle = sideCastle.ToUpper();
            return sideCastle;
        }

        private void CastleRook(bool isWhite, bool kingSide)
        {
            int startY = isWhite ? 7 : 0;
            int startX = kingSide ? 7 : 0;

            int endY = isWhite ? 7 : 0;
            int endX = kingSide ? 5 : 3;

            this.Pieces[endY, endX] = Pieces[startY, startX];
            this.Pieces[startY, startX] = null;
        }
    }
}
