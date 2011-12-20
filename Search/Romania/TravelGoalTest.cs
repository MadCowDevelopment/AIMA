using Search.Framework;

namespace Search.Romania
{
    public class TravelGoalTest : GoalTest<TravelState>
    {
        private readonly TravelState _goal;

        public TravelGoalTest(TravelState goal)
        {
            _goal = goal;
        }

        public override bool IsGoal(TravelState state)
        {
            return state == _goal;
        }
    }
}
