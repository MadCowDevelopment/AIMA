using Search.Types;

namespace Search.PathFinding
{
    public class PathFindingAction
    {
        public Point Point { get; set; }

        public PathFindingAction(Point point)
        {
            Point = point;
        }
    }
}
