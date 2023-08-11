using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;
using Xadrez2.Services;

namespace Xadrez2.Entities.Pieces
{
    internal class Bishop : Chesspiece
    {

        public Bishop(Point position, ConsoleColor color) : base(position, color) 
        {
            Name = "Bishop";
            XPossibilities = new int[2] { 1, -1};
            YPossibilities = new int[2] { 1, -1};
        }
        public override string ToString()
        {
            return "B";
        }
        internal override bool continueCondition(int possibilityX, int possibilityY)
        { return false; }
    }
    }

