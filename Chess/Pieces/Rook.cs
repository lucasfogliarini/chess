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

            int xIncrement = (startX == endX) ? 0 : (endX - startX) / Math.Abs(endX - startX);
            int yIncrement = (startY == endY) ? 0 : (endY - startY) / Math.Abs(endY - startY);

            // Check each piece on the path to the end position
            for (int x = startX + xIncrement, y = startY + yIncrement;
                 x != endX || y != endY; x += xIncrement, y += yIncrement)
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
