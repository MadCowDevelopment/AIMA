namespace Search.Framework
{
    public abstract class ResultFunction<TState, TAction>
    {
        public abstract TState Result(TState state, TAction action);
    }
}
