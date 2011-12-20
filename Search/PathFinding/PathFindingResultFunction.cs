using System;

using Search.Framework;

namespace Search.PathFinding
{
    public class PathFindingResultFunction : ResultFunction<PathFindingState, PathFindingAction>
    {
        public override PathFindingState Result(PathFindingState state, PathFindingAction action)
        {
            return new PathFindingState(action.Point);
        }
    }
}
