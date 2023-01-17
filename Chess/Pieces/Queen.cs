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
        public override bool IsValidMove(Board board, int startX, int startY, int endX, int endY)
        {
            // Check if the end position is on the same diagonal, row or column as the start position
            if (startX != endX && startY != endY && Math.Abs(endX - startX) != Math.Abs(endY - startY))
            {
                return false;
            }

            int xIncrement = (endX - startX) == 0 ? 0 : (endX - startX) / Math.Abs(endX - startX);
            int yIncrement = (endY - startY) == 0 ? 0 : (endY - startY) / Math.Abs(endY - startY);

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
