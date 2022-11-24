using System;
using System.Collections.Generic;
using System.Linq;
using Chessington.GameEngine;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> possibleMoves = new List<Square>();

            Player CurrentPlayer = this.Player == Player.White ? Player.White : Player.Black;
            var currentSquare = board.FindPiece(this);

            if (CurrentPlayer == Player.White)
            {
                if (currentSquare.Row == 0) goto ifEnd;
                var squareUp = Square.At(currentSquare.Row - 1, currentSquare.Col);

                if (board.isSquareEmpty(squareUp) == true)
                {
                    possibleMoves.Add(squareUp);

                    if (this.turnCount == 0)
                    {
                        var twoSquareUp = Square.At(currentSquare.Row - 2, currentSquare.Col);
                        if (board.isSquareEmpty(twoSquareUp) == true)
                        {
                            possibleMoves.Add(twoSquareUp);
                        }
                    }
                }
            }

            if (CurrentPlayer == Player.Black)
            {
                if (currentSquare.Row == 7) goto ifEnd;
                var squareDown = Square.At(currentSquare.Row + 1, currentSquare.Col);

                if (board.isSquareEmpty(squareDown) == true)
                {
                    possibleMoves.Add(squareDown);

                    if (this.turnCount == 0)
                    {
                        var twoSquareDown = Square.At(currentSquare.Row + 2, currentSquare.Col);
                        if (board.isSquareEmpty(twoSquareDown) == true)
                        {
                            possibleMoves.Add(twoSquareDown);
                        }
                    }
                }
            }

        ifEnd:

            return possibleMoves;
        }
    }
}

