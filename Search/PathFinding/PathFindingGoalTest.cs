using Search.Framework;

namespace Search.PathFinding
{
    public class PathFindingGoalTest : GoalTest<PathFindingState>
    {
        private readonly PathFindingState _goalState;

        public PathFindingGoalTest(PathFindingState goalState)
        {
            _goalState = goalState;
        }

        public override bool IsGoal(PathFindingState state)
        {
            return state.Point.X == _goalState.Point.X && state.Point.Y == _goalState.Point.Y;
        }
    }
}
