// -----------------------------------------------------------------------
// <copyright file="WeblinkStepCost.cs" company="Microsoft">
using Search.Framework;

namespace Search.Hyperlinks
{
    public class WeblinkStepCost : StepCost<WeblinkState, WeblinkAction>
    {
        public override double Cost(WeblinkState state, WeblinkAction action)
        {
            return 1;
        }
    }
}
