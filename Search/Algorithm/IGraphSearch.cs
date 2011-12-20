using System.Collections.Generic;

using Search.Framework;

namespace Search.Algorithm
{
    public interface IGraphSearch<TState, TAction>
    {
        List<Node<TState, TAction>> Search(Problem<TState, TAction> problem);
    }
}