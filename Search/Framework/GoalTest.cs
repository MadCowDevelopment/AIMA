namespace Search.Framework
{
    public abstract class GoalTest<TState>
    {
        public abstract bool IsGoal(TState state);
    }
}
