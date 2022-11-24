using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            List<Square> possibleMoves = new List<Square> {
                Square.At(currentSquare.Row + 2, currentSquare.Col + 1),
                Square.At(currentSquare.Row + 2, currentSquare.Col - 1),
                Square.At(currentSquare.Row - 2, currentSquare.Col + 1),
                Square.At(currentSquare.Row - 2, currentSquare.Col - 1),
                Square.At(currentSquare.Row + 1, currentSquare.Col + 2),
                Square.At(currentSquare.Row + 1, currentSquare.Col - 2),
                Square.At(currentSquare.Row - 1, currentSquare.Col + 2),
                Square.At(currentSquare.Row - 1, currentSquare.Col - 2)
                };

            possibleMoves.RemoveAll(s => 0 > s.Row || s.Row >= 8 || 0 > s.Col || s.Col >= 8);

            return possibleMoves;
        }
    }
}