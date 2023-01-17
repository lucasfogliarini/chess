namespace Chess.Pieces
{
    // Class to represent a pawn
    class Pawn : Piece
    {
        // Constructor
        public Pawn(bool isWhite) : base(isWhite) { }

        // Property to store the symbol for the piece
        public override char Symbol
        {
            get
            {
                return IsWhite ? 'P' : 'p';
            }
        }

        // Method to check if a move is valid
        public override bool IsValidMove(Board board, int startX, int startY, int endX, int endY)
        {
            if (CanCapture(board.Pieces[endY, endX]))
            {
                // Pawns can capture diagonally
                if ((!IsWhite && endY == startY + 1 && (endX == startX + 1 || endX == startX - 1)) ||
                    (IsWhite && endY == startY - 1 && (endX == startX + 1 || endX == startX - 1)))
                {
                    return true;
                }
            }
            else 
            {
                bool onlyInline = startX == endX;
                bool onlyForward = IsWhite && endY < startY || !IsWhite && endY > startY;
                if (onlyInline && onlyForward)
                {
                    int squares = Math.Abs(endY - startY);
                    if (squares == 1)
                        return true;
                    else if (squares == 2)
                        return InStartingPosition;
                }
            }

            return false;
        }
    }
}
