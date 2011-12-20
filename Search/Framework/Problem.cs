namespace Search.Framework
{
    public class Problem<TState, TAction>
    {
        public Problem(
            TState initalState, 
            ActionFunction<TState, TAction> actionFunction, 
            ResultFunction<TState, TAction> resultFunction, 
            GoalTest<TState> goalTest, StepCost<TState, TAction> stepCost)
        {
            InitalState = initalState;
            ActionFunction = actionFunction;
            ResultFunction = resultFunction;
            GoalTest = goalTest;
            StepCost = stepCost;
        }

        public TState InitalState { get; set; }

        public ActionFunction<TState, TAction> ActionFunction { get; set; }

        public ResultFunction<TState, TAction> ResultFunction { get; set; }

        public GoalTest<TState> GoalTest { get; set; }

        public StepCost<TState, TAction> StepCost { get; set; }
    }
}
