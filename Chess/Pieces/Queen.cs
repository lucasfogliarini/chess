namespace Chess.Pieces
{
    // Class to represent a queen
    class Queen : Piece
    {
        // Constructor
        public Queen(bool isWhite) : base(isWhite) { }

        // Property to store the symbol for the piece
        public override char Symbol
        {
            get
            {
                return IsWhite ? 'Q' : 'q';
            }
        }

        // Method to check if a move is valid
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Queens can move like bishops or rooks
            if (Math.Abs(endX - startX) == Math.Abs(endY - startY) || endX == startX || endY == startY)
            {
                return true;
            }

            return false;
        }
    }

}
