namespace Search.Framework
{
    public abstract class HeuristicFunction<TState>
    {
        public abstract double Cost(TState state);
    }
}
