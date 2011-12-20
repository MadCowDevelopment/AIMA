using Search.Types;

namespace Search.PathFinding
{
    public class PathFindingState
    {
        public Point Point { get; private set; }

        public PathFindingState(Point point)
        {
            Point = point;
        }

        public override string ToString()
        {
            return string.Format("P({0}, {1})", Point.X, Point.Y);
        }
    }
}
