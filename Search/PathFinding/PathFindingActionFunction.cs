using System.Collections.Generic;
using System.Linq;

using Search.Framework;
using Search.Types;

namespace Search.PathFinding
{
    public class PathFindingActionFunction : ActionFunction<PathFindingState, PathFindingAction>
    {
        private readonly PathFindingEnvironment _environment;

        private readonly PathFindingState _goalState;

        public PathFindingActionFunction(PathFindingEnvironment environment, PathFindingState goalState)
        {
            _environment = environment;
            _goalState = goalState;
        }

        public override List<PathFindingAction> Actions(PathFindingState state)
        {
            var result = new List<PathFindingAction>();

            var points1 = _environment.PointLines.Select(p => p.Point1);
            var points2 = _environment.PointLines.Select(p => p.Point2);

            var points = points1.Union(points2).Distinct().ToList();
            points.Add(_goalState.Point);
            
            foreach (var point in points)
            {
                if (!PathIntersectsAnyPointLine(state, point))
                {
                    result.Add(new PathFindingAction(point));
                }
            }

            return result;
        }

        private bool PathIntersectsAnyPointLine(PathFindingState state, Point point)
        {
            var pathPointLine = new PointLine(state.Point, point);

            foreach (var pointLine in _environment.PointLines)
            {
                if (PathIntersectsPointLine(state, pointLine, pathPointLine, point))
                {
                    return true;
                }
            }

            return false;
        }

        private bool PathIntersectsPointLine(PathFindingState state, PointLine pointLine, PointLine pathPointLine, Point point)
        {
            if (pathPointLine.M == pointLine.M)
            {
                return false;
            }

            double intersection;
            if (double.IsInfinity(pathPointLine.M) && double.IsInfinity(pointLine.M))
            {
                return false;
            }
            else if (double.IsInfinity(pathPointLine.M))
            {
                intersection = pathPointLine.Point1.X;
            }
            else if (double.IsInfinity(pointLine.M))
            {
                intersection = pointLine.Point1.X;
            }
            else
            {
                var x = pathPointLine.M - pointLine.M;
                var t = pointLine.T - pathPointLine.T;
                intersection = t / x;
            }

            if (state.Point.X < point.X)
            {
                if (intersection <= state.Point.X || intersection >= point.X)
                {
                    return false;
                }
            }
            else
            {
                if (intersection >= state.Point.X || intersection <= point.X)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
