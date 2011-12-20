using System;

using Search.Framework;

namespace Search.PathFinding
{
    public class PathFindingStepCost : StepCost<PathFindingState, PathFindingAction>
    {
        public override double Cost(PathFindingState state, PathFindingAction action)
        {
            return 1;
        }
    }
}
