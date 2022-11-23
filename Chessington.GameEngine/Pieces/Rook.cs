using System.Collections.Generic;
using System.Linq;
using System;

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

            for (var i = currentSquare.Row + 1; i < 8; i++)
            {
                if (board.isSquareEmpty(Square.At(i, currentSquare.Col)))
                {
                    possibleMoves.Add(Square.At(i, currentSquare.Col));
                }
                else break;
            }

            for (var i = currentSquare.Row - 1; i >= 0; i--)
            {
                if (board.isSquareEmpty(Square.At(i, currentSquare.Col)))
                {
                    possibleMoves.Add(Square.At(i, currentSquare.Col));
                }
                else break;
            }

            for (var i = currentSquare.Col + 1; i < 8; i++)
            {
                if (board.isSquareEmpty(Square.At(currentSquare.Row, i)))
                {
                    possibleMoves.Add(Square.At(currentSquare.Row, i));
                }
                else break;
            }

            for (var i = currentSquare.Col - 1; i >= 0; i--)
            {
                if (board.isSquareEmpty(Square.At(currentSquare.Row, i)))
                {
                    possibleMoves.Add(Square.At(currentSquare.Row, i));
                }
                else break;
            }

            possibleMoves.RemoveAll(s => s == currentSquare);

            return possibleMoves;
        }
    }
}