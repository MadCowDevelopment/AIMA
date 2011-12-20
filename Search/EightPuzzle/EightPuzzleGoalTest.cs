using Search.Framework;

namespace Search.EightPuzzle
{
    public class EightPuzzleGoalTest : GoalTest<EightPuzzleState>
    {
        private readonly EightPuzzleState _goal;

        public EightPuzzleGoalTest(EightPuzzleState goal)
        {
            _goal = goal;
        }

        public override bool IsGoal(EightPuzzleState state)
        {
            return _goal.Equals(state);
        }
    }
}
