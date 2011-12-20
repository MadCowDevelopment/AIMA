namespace Search.Framework
{
    public abstract class StepCost<TState, TAction>
    {
        public abstract double Cost(TState state, TAction action);
    }
}
