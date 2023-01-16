namespace Chess.Pieces
{
    // Class to represent a rook
    class Rook : Piece
    {
        // Constructor
        public Rook(bool isWhite) : base(isWhite) { }

        // Property to store the symbol for the piece
        public override char Symbol
        {
            get
            {
                return IsWhite ? 'R' : 'r';
            }
        }

        // Method to check if a move is valid
        public override bool IsValidMove(Board board, int startX, int startY, int endX, int endY)
        {
            // Rooks can only move horizontally or vertically
            if (endX != startX && endY != startY)
            {
                return false;
            }

            return base.IsValidMove(board, startX, startY, endX, endY);
        }
    }

}
