using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;
using Xadrez2.Services;

namespace Xadrez2.Entities.Pieces
{
    internal class Knight : Chesspiece
    {

        public Knight(Point position, ConsoleColor color) : base(position, color) 
        {
            Name = "Knight";

            XPossibilities = new int[4] { 2, -2, 1, -1 };
            YPossibilities = new int[4] { 2, -2, 1, -1 };
            OnlyOne = true;

        }
        public override string ToString()
        {
            return "C";
        }
        internal override bool continueCondition(int possibilityX, int possibilityY)
        { return (ConvertP.PositiveOf(possibilityX)) == (ConvertP.PositiveOf(possibilityY)); }

        
    }
    }

