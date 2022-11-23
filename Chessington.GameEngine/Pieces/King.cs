using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> possibleMoves = new List<Square>();

            var currentSquare = board.FindPiece(this);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(currentSquare.Row - i) <= 1 && Math.Abs(currentSquare.Col - j) <= 1)
                    {
                        possibleMoves.Add(Square.At(i, j));
                    }
                }
            }

            possibleMoves.RemoveAll(s => s == currentSquare);

            return possibleMoves;
        }
    }
}