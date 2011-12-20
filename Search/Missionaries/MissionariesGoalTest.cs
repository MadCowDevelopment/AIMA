using Search.Framework;

namespace Search.Missionaries
{
    public class MissionariesGoalTest : GoalTest<MissionariesState>
    {
        private readonly MissionariesState _goalState;

        public MissionariesGoalTest(MissionariesState goalState)
        {
            _goalState = goalState;
        }

        public override bool IsGoal(MissionariesState state)
        {
            if (state.CannibalsBoat == _goalState.CannibalsBoat && 
                state.CannibalsLeft == _goalState.CannibalsLeft &&
                state.CannibalsRight == _goalState.CannibalsRight &&
                state.MissionariesBoat == _goalState.MissionariesBoat && 
                state.MissionariesLeft == _goalState.MissionariesLeft && 
                state.MissionariesRight == _goalState.MissionariesRight)
            {
                return true;
            }

            return false;
        }
    }
}
