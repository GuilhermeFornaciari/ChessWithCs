using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez2.Entities;


namespace Xadrez2.Services
{
    static class ConvertP
    {
        public static Point StrToPoint(string Position)
        {
            List<string> letters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };
            
            int X = letters.IndexOf(Position.Substring(0, 1));
            int Y = int.Parse(Position.Substring(1)) - 1;
            return new Point(X, Y);
        }
        public static string PointToStr(Point Position)
        {
            string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            string X = letters[Position.X];
            return X + (Position.Y +1);
        }
        public static int PositiveOf(int number) 
        {
            return number > 0 ? number : -number;
        }

    }
}
