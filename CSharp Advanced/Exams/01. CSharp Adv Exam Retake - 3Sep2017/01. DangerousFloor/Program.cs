namespace _01.DangerousFloor
{
    using System;
    using System.Linq;

    class Program
    {
        private static string[][] board = new string[8][];

        static void Main(string[] args)
        {
            InitializeBoard();
            MovePieces();
        }

        private static void InitializeBoard()
        {
            for(int row = 0; row < 8; row++)
            {
                board[row] = Console.ReadLine().Split(',').ToArray();
            }
        }

        private static void MovePieces()
        {
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split('-');
                string pieceType = cmdArgs[0][0].ToString();
                int startRow = int.Parse(cmdArgs[0][1].ToString());
                int startCol = int.Parse(cmdArgs[0][2].ToString());
                int endRow = int.Parse(cmdArgs[1][0].ToString());
                int endCol = int.Parse(cmdArgs[1][1].ToString());

                if (!CheckForPieceType(pieceType, startRow, startCol))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if(!IsValidMove(pieceType, startRow, startCol, endRow, endCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (!IsValidEndCell(endRow, endCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                MovePiece(pieceType, startRow, startCol, endRow, endCol);
            }
        }

        private static void MovePiece(string pieceType, int startRow, int startCol, int endRow, int endCol)
        {
            board[startRow][startCol] = "x";
            board[endRow][endCol] = pieceType;
        }

        private static bool CheckForPieceType(string pieceType, int startRow, int startCol)
        {
            if(startRow < 0 || startRow > board.Length - 1)
            {
                return false;
            }

            return board[startRow][startCol].Equals(pieceType);
        }

        private static bool IsValidMove(string pieceType, int startRow, int startCol, int endRow, int endCol)
        {
            switch(pieceType)
            {
                case "K":
                    return IsValidMoveKing(startRow, startCol, endRow, endCol);

                case "R":
                    return IsValidMoveRook(startRow, startCol, endRow, endCol);

                case "B":
                    return IsValidMoveBishop(startRow, startCol, endRow, endCol);

                case "Q":
                    return IsValidMoveQueen(startRow, startCol, endRow, endCol);

                case "P":
                    return IsValidMovePawn(startRow, startCol, endRow, endCol);

                default:
                    return false;
            }
        }

        private static bool IsValidMoveKing(int startRow, int startCol, int endRow, int endCol)
        {
            // horizontally one square
            if (startRow == endRow && Math.Abs(startCol - endCol) == 1)
            {
                return true;
            }

            // vertically one square
            if (startCol == endCol && Math.Abs(startRow - endRow) == 1)
            {
                return true;
            }

            // diagonally one square
            if (startRow != endRow && startCol != endCol &&
                Math.Abs(startRow - endRow) == 1 && Math.Abs(startCol - endCol) == 1)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidMoveRook(int startRow, int startCol, int endRow, int endCol)
        {
            // horizontally
            if (startRow == endRow && startCol != endCol)
            {
                return true;
            }

            // vertically
            if (startCol == endCol && startRow != endRow)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidMoveBishop(int startRow, int startCol, int endRow, int endCol)
        {
            // diagonally
            if (startRow != endRow && startCol != endCol &&
                Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidMoveQueen(int startRow, int startCol, int endRow, int endCol)
        {
            // horizontally
            if (startRow == endRow && startCol != endCol)
            {
                return true;
            }

            // vertically
            if (startCol == endCol && startRow != endRow)
            {
                return true;
            }

            // diagonally
            if (startRow != endRow && startCol != endCol &&
                Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidMovePawn(int startRow, int startCol, int endRow, int endCol)
        {
            // one square to the top
            if (startCol == endCol && (startRow - endRow) == 1)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidEndCell(int endRow, int endCol)
        {
            return endRow >= 0 &&
                   endRow < board.Length &&
                   endRow >= 0 &&
                   endCol < board[0].Length;
        }
    }
}
