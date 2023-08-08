using Xadrez2.Services;

namespace Xadrez2.Entities
{
    internal struct Point : IComparable
    {
        public int X{ get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            string pos = ConvertP.PointToStr(this);
            return pos;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Point)) throw new ArgumentException("Comparing error");
            Point other = (Point)obj;
            if (other.Y > Y) return -1 ;
            if (other.Y < Y) return 1;
            else
            {
                if (other.X > X) return -1 ;
                if (other.X < X) return 1;
            }
            return 0;

        }

    }
}
