using Search.Framework;

namespace Search.EightPuzzle
{
    public class EightPuzzleStepCost : StepCost<EightPuzzleState, EightPuzzleAction>
    {
        public override double Cost(EightPuzzleState state, EightPuzzleAction action)
        {
            return 1;
        }
    }
}
