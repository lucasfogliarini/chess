﻿using Chess.Pieces;

namespace Chess
{
    // Class to represent the chess board
    class Board
    {
        // Two-dimensional array to hold the pieces
        private Piece[,] pieces = new Piece[8, 8];

        // Constructor to set up the board
        public Board()
        {
            // Initialize the pieces
            pieces[0, 0] = new Rook(true);
            pieces[0, 1] = new Knight(true);
            pieces[0, 2] = new Bishop(true);
            pieces[0, 3] = new Queen(true);
            pieces[0, 4] = new King(true);
            pieces[0, 5] = new Bishop(true);
            pieces[0, 6] = new Knight(true);
            pieces[0, 7] = new Rook(true);
            for (int i = 0; i < 8; i++)
            {
                pieces[1, i] = new Pawn(true);
                pieces[6, i] = new Pawn(false);
            }
            pieces[7, 0] = new Rook(false);
            pieces[7, 1] = new Knight(false);
            pieces[7, 2] = new Bishop(false);
            pieces[7, 3] = new Queen(false);
            pieces[7, 4] = new King(false);
            pieces[7, 5] = new Bishop(false);
            pieces[7, 6] = new Knight(false);
            pieces[7, 7] = new Rook(false);
        }

        // Method to print the board to the console
        public void Print()
        {
            // Print the column labels
            Console.Write("  ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(" " + (char)('a' + x));
            }
            Console.WriteLine();

            // Print the rows
            for (int y = 0; y < 8; y++)
            {
                // Print the row label
                Console.Write((8 - y) + " ");

                // Print the pieces
                for (int x = 0; x < 8; x++)
                {
                    if (pieces[y, x] == null)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(pieces[y, x].Symbol);
                    }
                    Console.Write(" ");
                }

                // Print the row label again
                Console.Write((8 - y));

                Console.WriteLine();
            }

            // Print the column labels
            Console.Write("  ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(" " + (char)('a' + x));
            }
            Console.WriteLine();
        }


        // Method to make a move
        public void MovePiece(int startX, int startY, int endX, int endY)
        {
            // Make sure the start and end positions are on the board
            if (startX < 0 || startX > 7 || startY < 0 || startY > 7 || endX < 0 || endX > 7 || endY < 0 || endY > 7)
            {
                Console.WriteLine("Invalid move.");
                return;
            }

            // Make sure there is a piece at the start position
            if (pieces[startY, startX] == null)
            {
                Console.WriteLine("There is no piece at the start position.");
                return;
            }

            // Check if the move is valid for the piece
            if (!pieces[startY, startX].IsValidMove(startX, startY, endX, endY))
            {
                Console.WriteLine("Invalid move for that piece.");
                return;
            }

            // Make the move
            pieces[endY, endX] = pieces[startY, startX];
            pieces[startY, startX] = null;
        }

        // Method to make a move
        public void MovePiece(string move)
        {
            // Parse the move string into start and end coordinates
            int startX = move[0] - 'a';
            int startY = 8 - (move[1] - '0');
            int endX = move[2] - 'a';
            int endY = 8 - (move[3] - '0');

            // Make sure the start and end positions are on the board
            if (startX < 0 || startX > 7 || startY < 0 || startY > 7 || endX < 0 || endX > 7 || endY < 0 || endY > 7)
            {
                Console.WriteLine("Invalid move.");
                return;
            }

            // Make sure there is a piece at the start position
            if (pieces[startY, startX] == null)
            {
                Console.WriteLine("There is no piece at the start position.");
                return;
            }

            // Check if the move is valid for the piece
            if (!pieces[startY, startX].IsValidMove(startX, startY, endX, endY))
            {
                Console.WriteLine("Invalid move for that piece.");
                return;
            }

            // Make the move
            pieces[endY, endX] = pieces[startY, startX];
            pieces[startY, startX] = null;
        }

    }
}
