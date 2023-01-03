namespace Chess.Pieces
{
    // Class to represent a knight
    class Knight : Piece
    {
        // Constructor
        public Knight(bool isWhite) : base(isWhite) { }

        // Property to store the symbol for the piece
        public override char Symbol
        {
            get
            {
                return IsWhite ? 'N' : 'n';
            }
        }

        // Method to check if a move is valid
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Knights can move in an L-shape
            if (Math.Abs(endX - startX) == 2 && Math.Abs(endY - startY) == 1 ||
                Math.Abs(endX - startX) == 1 && Math.Abs(endY - startY) == 2)
            {
                return true;
            }

            return false;
        }
    }

}
