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
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Pawns can only move forward
            if (IsWhite && endY > startY)
            {
                return false;
            }
            if (!IsWhite && endY < startY)
            {
                return false;
            }

            // Pawns can move one or two squares forward on their first move
            if (!IsWhite && startY == 1 && endY == 3 && startX == endX || IsWhite && startY == 6 && endY == 4 && startX == endX)
            {
                return true;
            }

            // Pawns can only move one square forward otherwise
            if (endY - startY != 1 || startX != endX)
            {
                return false;
            }

            return true;
        }

        //public bool IsValidMove(Board board, string move)
        //{
        //    int endX = move[0] - 'a';
        //    int endY = (move[1] - '0') - 1;
        //    // board.Pieces
        //}
    }
}
