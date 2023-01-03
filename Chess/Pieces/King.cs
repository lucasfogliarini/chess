using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    // Class to represent a king
    class King : Piece
    {
        // Constructor
        public King(bool isWhite) : base(isWhite) { }

        // Property to store the symbol for the piece
        public override char Symbol
        {
            get
            {
                return IsWhite ? 'K' : 'k';
            }
        }

        // Method to check if a move is valid
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Kings can only move one square in any direction
            if (Math.Abs(endX - startX) > 1 || Math.Abs(endY - startY) > 1)
            {
                return false;
            }

            return true;
        }
    }

}
