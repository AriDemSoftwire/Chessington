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
                        else if (CurrentPlayer != board.GetPiece(Square.At(i, j)).Player)
                        {
                            possibleMoves.Add(Square.At(i, j));
                            goto LoopEnd1;
                        }
                        else goto LoopEnd1;
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
                        else if (CurrentPlayer != board.GetPiece(Square.At(i, j)).Player)
                        {
                            possibleMoves.Add(Square.At(i, j));
                            goto LoopEnd2;
                        }
                        else goto LoopEnd2;
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
                        else if (CurrentPlayer != board.GetPiece(Square.At(i, j)).Player)
                        {
                            possibleMoves.Add(Square.At(i, j));
                            goto LoopEnd3;
                        }
                        else goto LoopEnd3;
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
                        else if (CurrentPlayer != board.GetPiece(Square.At(i, j)).Player)
                        {
                            possibleMoves.Add(Square.At(i, j));
                            goto LoopEnd4;
                        }
                        else goto LoopEnd4;
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
                else if (CurrentPlayer != board.GetPiece(Square.At(i, currentSquare.Col)).Player)
                {
                    possibleMoves.Add(Square.At(i, currentSquare.Col));
                    break;
                }
                else break;
            }

            for (var i = currentSquare.Row - 1; i >= 0; i--)
            {
                if (board.isSquareEmpty(Square.At(i, currentSquare.Col)))
                {
                    possibleMoves.Add(Square.At(i, currentSquare.Col));
                }
                else if (CurrentPlayer != board.GetPiece(Square.At(i, currentSquare.Col)).Player)
                {
                    possibleMoves.Add(Square.At(i, currentSquare.Col));
                    break;
                }
                else break;
            }

            for (var i = currentSquare.Col + 1; i < 8; i++)
            {
                if (board.isSquareEmpty(Square.At(currentSquare.Row, i)))
                {
                    possibleMoves.Add(Square.At(currentSquare.Row, i));
                }
                else if (CurrentPlayer != board.GetPiece(Square.At(currentSquare.Row, i)).Player)
                {
                    possibleMoves.Add(Square.At(currentSquare.Row, i));
                    break;
                }
                else break;
            }

            for (var i = currentSquare.Col - 1; i >= 0; i--)
            {
                if (board.isSquareEmpty(Square.At(currentSquare.Row, i)))
                {
                    possibleMoves.Add(Square.At(currentSquare.Row, i));
                }
                else if (CurrentPlayer != board.GetPiece(Square.At(currentSquare.Row, i)).Player)
                {
                    possibleMoves.Add(Square.At(currentSquare.Row, i));
                    break;
                }
                else break;
            }

            possibleMoves.RemoveAll(s => s == currentSquare);

            return possibleMoves;
        }
    }
}