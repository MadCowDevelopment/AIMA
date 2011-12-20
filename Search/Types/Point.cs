namespace Search.Types
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(Point))
            {
                return false;
            }
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)X * 397) ^ (int)Y;
            }
        }
    }
}
