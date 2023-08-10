﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities.Pieces;
using Xadrez2.Services;

namespace Xadrez2.Entities
{
    internal class Chessboard
    {
        public Chesspiece[,] board { get; private set; }

        private Dictionary<bool, ConsoleColor> BgColors { get; set; }

        public List<String> CapturedPiecesRed { get; set; }

        public List<String> CapturedPiecesBlue { get; set; }

        public Chessboard()
        {
            board = new Chesspiece[8, 8];
            BgColors = new Dictionary<bool, ConsoleColor>
            {
                {  true,ConsoleColor.Gray },
                { false,ConsoleColor.DarkGray }
            };
            CapturedPiecesRed = new List<String>();
            CapturedPiecesBlue = new List<String>();



            /*
            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = new Pawn(new Point(i,1), ConsoleColor.DarkRed);
            }

            for (int i = 0; i < 8; i++)
            {
                board[i, 6] = new Pawn(new Point(i,6), ConsoleColor.DarkBlue);
            }
            */

            /*
            board[0, 0] = new Rook(new Point(0, 0), ConsoleColor.DarkRed);
            board[7, 0] = new Rook(new Point(7, 0), ConsoleColor.DarkRed);

            board[0, 7] = new Rook(new Point(0, 7), ConsoleColor.DarkBlue);
            board[7, 7] = new Rook(new Point(7, 7), ConsoleColor.DarkBlue);
            */

            board[5, 5] = new Rook(new Point(5, 5), ConsoleColor.DarkRed);
            board[4, 4] = new Rook(new Point(4, 4), ConsoleColor.DarkBlue);









        }

        private void ResetCmd()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void printPositonName(Chesspiece ChessHouse)
        {
            if (ChessHouse != null)
            {
                Console.Write(ChessHouse.ToString() + " ");
            }
            else
            {
                Console.Write("  ");
            }
        }
        public string MovePiece(Point piecePosition)
        {
            Chesspiece Piece = board[piecePosition.X, piecePosition.Y];
            List<Point> AttackPoints = Piece.Move(board);

            if (AttackPoints.Count == 0 ) return "NoMoves";


            Printboard(AttackPoints);
            string PlayerMove = CollectCMDInput.MovePiece(AttackPoints);
            if (PlayerMove != "")
            {
                Point NewPosition = ConvertP.StrToPoint(PlayerMove);
                CapturePiece(Piece, NewPosition);
                Piece.Moved = true;

                board[NewPosition.X, NewPosition.Y] = Piece;
                board[Piece.Position.X, Piece.Position.Y] = null;

                Piece.Position = NewPosition;

                return "No";


            }

            else return "Skipped";


        }

        private void CapturePiece(Chesspiece piece, Point newPosition)
        {
            if (board[newPosition.X, newPosition.Y] != null)
            {
                if (piece.Color == ConsoleColor.DarkBlue) 
                    CapturedPiecesBlue.Add(board[newPosition.X, newPosition.Y].Name);
                else 
                    CapturedPiecesRed .Add(board[newPosition.X, newPosition.Y].Name);
            }
        }



        public void Printboard(List<Point>? attacksList)
        {
            Console.Clear();

            List<Point>? attacks = null;
            if (attacksList != null) attacks = new List<Point>(attacksList);

            bool Color = false;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int y = 0; y < board.GetLength(1); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    Console.BackgroundColor = BgColors[Color];
                    Color = !Color;

                    if (board[x, y] != null) Console.ForegroundColor = board[x, y].Color;

                    if (attacks != null && attacks.Count > 0)
                    {
                        if (attacks[0].X == x && attacks[0].Y == y)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            attacks.RemoveAt(0);
                        }
                    }
                    printPositonName(board[x, y]);
                }
                ResetCmd();
                Console.WriteLine((y + 1) + " ");
                Console.ForegroundColor = ConsoleColor.Black;
                Color = !Color;
            }
            ResetCmd();

            string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            foreach (string letter in letters)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();

        }

    }
}

/*
bool attacked = false;
foreach (string attack in attacks)
{
    int positionY = letters.IndexOf(attack.Substring(0, 1));
    if (int.Parse(attack.Substring(1)) == x && positionY == y)
        attacked = true;
}
*/