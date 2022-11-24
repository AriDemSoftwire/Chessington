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


            for (int i = currentSquare.Row + 1; i < 8; i++)
            {
                for (int j = currentSquare.Col + 1; j < 8; j++)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        if (board.isSquareEmpty(Square.At(i, j)))
                        {
                            possibleMoves.Add(Square.At(i, j));
                        }

                        else
                        {
                            goto LoopEnd1;
                        }
                    }
                }
            }
        LoopEnd1:

            for (int i = currentSquare.Row + 1; i < 8; i++)
            {
                for (int j = currentSquare.Col - 1; j >= 0; j--)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        if (board.isSquareEmpty(Square.At(i, j)))
                        {
                            possibleMoves.Add(Square.At(i, j));
                        }
                        else
                        {
                            goto LoopEnd2;
                        }
                    }
                }
            }
        LoopEnd2:

            for (int i = currentSquare.Row - 1; i >= 0; i--)
            {
                for (int j = currentSquare.Col - 1; j >= 0; j--)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        if (board.isSquareEmpty(Square.At(i, j)))
                        {
                            possibleMoves.Add(Square.At(i, j));
                        }
                        else
                        {
                            goto LoopEnd3;
                        }
                    }
                }
            }
        LoopEnd3:

            for (int i = currentSquare.Row - 1; i >= 0; i--)
            {
                for (int j = currentSquare.Col + 1; j < 8; j++)
                {
                    if (Math.Abs(currentSquare.Row - i) == Math.Abs(currentSquare.Col - j))
                    {
                        if (board.isSquareEmpty(Square.At(i, j)))
                        {
                            possibleMoves.Add(Square.At(i, j));
                        }
                        else
                        {
                            goto LoopEnd4;
                        }
                    }
                }
            }

        LoopEnd4:

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