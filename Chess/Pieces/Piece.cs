namespace Chess.Pieces
{
    // Abstract class to represent a chess piece
    abstract class Piece
    {
        // Property to store the color of the piece (true for white, false for black)
        public bool IsWhite { get; private set; }

        public bool InStartingPosition { get; set; } = true;

        // Property to store the symbol for the piece
        public abstract char Symbol { get; }

        // Constructor
        public Piece(bool isWhite)
        {
            IsWhite = isWhite;
        }

        public static Piece Generate(char symbol)
        {
            switch (char.ToLower(symbol))
            {
                case 'p':
                    return new Pawn(char.IsUpper(symbol));
                case 'r':
                    return new Rook(char.IsUpper(symbol));
                case 'n':
                    return new Knight(char.IsUpper(symbol));
                case 'b':
                    return new Bishop(char.IsUpper(symbol));
                case 'q':
                    return new Queen(char.IsUpper(symbol));
                case 'k':
                    return new King(char.IsUpper(symbol));
                default:
                    throw new ArgumentException($"Não existe uma peça com esse símbolo {symbol}.");
            }
        }

        // Method to check if a move is valid
        public virtual bool IsValidMove(Board board, int startX, int startY, int endX, int endY)
        {
            var endPiece = board.Pieces[endY, endX];
            return endPiece == null || CanCapture(endPiece);
        }

        protected bool CanCapture(Piece endPiece)
        {
            return endPiece != null && endPiece.IsWhite != IsWhite;
        }
    }
}
