using Search.Framework;

namespace Search.Missionaries
{
    public class MissionariesStepCost : StepCost<MissionariesState, MissionariesAction>
    {
        public override double Cost(MissionariesState state, MissionariesAction action)
        {
            return 1;
        }
    }
}
