using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;
using Xadrez2.Services;

namespace Xadrez2.Entities.Pieces
{
    internal class Rook : Chesspiece
    {

        public Rook(Point position, ConsoleColor color) : base(position, color)
        {
            Name = "Rook";
            XPossibilities = new int[3] { 1, -1, 0 };
            YPossibilities = new int[3] { 1, -1, 0 };
        }
        public override string ToString()
        {
            return "R";
        }

        internal override bool continueCondition(int possibilityX, int possibilityY)
        { return (ConvertP.PositiveOf(possibilityX) + ConvertP.PositiveOf(possibilityY) > 1); }

    }

    }

