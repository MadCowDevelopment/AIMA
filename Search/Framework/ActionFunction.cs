using System.Collections.Generic;

namespace Search.Framework
{
    public abstract class ActionFunction<TState, TAction>
    {
        public abstract List<TAction> Actions(TState state);
    }
}
