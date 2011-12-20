using Search.Framework;

namespace Search.Hyperlinks
{
    public class WeblinkGoalTest : GoalTest<WeblinkState>
    {
        private readonly WeblinkState _goal;

        public WeblinkGoalTest(WeblinkState goal)
        {
            _goal = goal;
        }

        public override bool IsGoal(WeblinkState state)
        {
            if (_goal.Url.Equals(state.Url))
            {
                return true;
            }

            return false;
        }
    }
}
