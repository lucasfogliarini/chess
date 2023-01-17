namespace Chess.Pieces
{
    // Class to represent a bishop
    class Bishop : Piece
    {
        // Constructor
        public Bishop(bool isWhite) : base(isWhite) { }

        // Property to store the symbol for the piece
        public override char Symbol
        {
            get
            {
                return IsWhite ? 'B' : 'b';
            }
        }

        // Method to check if a move is valid
        public override bool IsValidMove(Board board, int startX, int startY, int endX, int endY)
        {
            // Bishops can only move diagonally
            if (Math.Abs(endX - startX) != Math.Abs(endY - startY))
            {
                return false;
            }

            int xIncrement = (endX - startX) / Math.Abs(endX - startX);
            int yIncrement = (endY - startY) / Math.Abs(endY - startY);

            // Check each piece on the path to the destination
            for (int x = startX + xIncrement, y = startY + yIncrement;
                 x != endX; x += xIncrement, y += yIncrement)
            {
                if (board.Pieces[y, x] != null)
                {
                    return false;
                }
            }

            return base.IsValidMove(board, startX, startY, endX, endY);
        }
    }

}
