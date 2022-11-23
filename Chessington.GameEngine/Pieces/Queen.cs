using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> possibleMoves = new List<Square>();

            Player CurrentPlayer = this.Player == Player.White ? Player.White : Player.Black;
            var currentSquare = board.FindPiece(this);

            for (int i = currentSquare.Row; i < 8; i++)
            {
                for (int j = currentSquare.Col; j < 8; j++)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        possibleMoves.Add(Square.At(i, j));
                    }
                }
            }

            for (int i = currentSquare.Row; i < 8; i++)
            {
                for (int j = currentSquare.Col; j >= 0; j--)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        possibleMoves.Add(Square.At(i, j));
                    }
                }
            }

            for (int i = currentSquare.Row; i >= 0; i--)
            {
                for (int j = currentSquare.Col; j >= 0; j--)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        possibleMoves.Add(Square.At(i, j));
                    }
                }
            }

            for (int i = currentSquare.Row; i >= 0; i--)
            {
                for (int j = currentSquare.Col; j < 8; j++)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        possibleMoves.Add(Square.At(i, j));
                    }
                }
            }

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