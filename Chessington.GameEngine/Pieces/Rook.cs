using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> possibleMoves = new List<Square>();

            Player CurrentPlayer = this.Player == Player.White ? Player.White : Player.Black;
            var currentSquare = board.FindPiece(this);

            for (var i = currentSquare.Row; i < 8; i++)
            {
                possibleMoves.Add(Square.At(i, currentSquare.Col));
            }

            for (var i = currentSquare.Row; i >= 0; i--)
            {
                possibleMoves.Add(Square.At(i, currentSquare.Col));
            }

            for (var i = currentSquare.Col; i < 8; i++)
            {
                possibleMoves.Add(Square.At(currentSquare.Row, i));
            }

            for (var i = currentSquare.Col; i >= 0; i--)
            {
                possibleMoves.Add(Square.At(currentSquare.Row, i));
            }

            possibleMoves.RemoveAll(s => s == currentSquare);

            return possibleMoves;
        }
    }
}