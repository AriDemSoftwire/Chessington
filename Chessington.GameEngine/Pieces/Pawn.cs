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
                Console.WriteLine("white");
                var squareUp = Square.At(currentSquare.Row - 1, currentSquare.Col);
                if (board.isSquareEmpty(squareUp) == true)
                {
                    possibleMoves.Add(squareUp);
                }
            }

            if (CurrentPlayer == Player.Black)
            {
                Console.WriteLine("black");
                var squareDown = Square.At(currentSquare.Row + 1, currentSquare.Col);
                if (board.isSquareEmpty(squareDown) == true)
                {
                    possibleMoves.Add(squareDown);
                }
            }

            return possibleMoves;
        }
    }
}

