using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;
using Xadrez2.Services;

namespace Xadrez2.Entities.Pieces
{
    internal class King : Chesspiece
    {
        public King(Point position, ConsoleColor color) : base(position, color) 
        {
            Name = "King";
            XPossibilities = new int[3] { 1, -1, 0 };
            YPossibilities = new int[3] { 1, -1, 0 };
            OnlyOne = true;

        }
        public override string ToString()
        {
            return "K";
        }
        internal override bool continueCondition(int possibilityX, int possibilityY)
        { return false; }
    }
    }

