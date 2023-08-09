﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez2.Entities
{
    internal abstract class Chesspiece
    {
        internal bool Moved { get; set; }

        public ConsoleColor Color { get; set; }

        public string Name { get; set; }
        public Chesspiece(Point position, ConsoleColor color) 
        {
            Position = position;
            Color = color;

        }

        public bool IsEnemy(Chesspiece piece)
        {
            if (piece.Color != this.Color) return true;
            else return false;
        }
        
        public abstract List<Point> Move(Chesspiece[,] Chessboard);

        private Point _position;

        public Point Position
        {
            get { return _position; }
            set { 
                _position.X = value.X;
                _position.Y = value.Y;
            }
        }

    }
}
