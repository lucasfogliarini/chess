namespace Chess.Pieces
{
    // Abstract class to represent a chess piece
    abstract class Piece
    {
        // Property to store the color of the piece (true for white, false for black)
        public bool IsWhite { get; private set; }

        // Property to store the symbol for the piece
        public abstract char Symbol { get; }

        // Constructor
        public Piece(bool isWhite)
        {
            IsWhite = isWhite;
        }

        // Method to check if a move is valid
        public abstract bool IsValidMove(int startX, int startY, int endX, int endY);
    }
}
