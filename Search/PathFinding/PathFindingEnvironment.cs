using System;
using System.Collections.Generic;

using Search.Types;

namespace Search.PathFinding
{
    public class PathFindingEnvironment
    {
        public PathFindingEnvironment()
        {
            PointLines = new List<PointLine>();
        }

        public List<PointLine> PointLines { get; private set; }
    }

    public class PointLine
    {
        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public double M { get; set; }

        public double T { get; set; }

        public PointLine(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;

            M = (Point2.Y - Point1.Y) / (double)(Point2.X - Point1.X);
            T = Point1.Y - (M * Point1.X);
        }
    }
}
