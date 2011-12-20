using System.Collections.Generic;

namespace Search.Framework
{
    public class Node<TState, TAction>
    {
        public TState State { get; set; }
        public Node<TState, TAction> Parent { get; set; }
        public TAction Action { get; set; }
        public double PathCost { get; set; }

        public Node(TState state)
        {
            State = state;
            PathCost = 0.0f;
        }

        public Node(TState state, Node<TState, TAction> parent, TAction action, double pathCost)
        {
            State = state;
            Parent = parent;
            Action = action;
            PathCost = pathCost;
        }

        public int Depth
        {
            get
            {
                int depth = 0;
                var current = this;
                while (current.Parent != null)
                {
                    depth++;
                    current = current.Parent;
                }

                return depth;
            }
        }

        public double TotalCost
        {
            get
            {
                double cost = PathCost;
                if (Parent != null)
                {
                    cost += Parent.PathCost;
                }

                return cost;
            }
        }

        public List<Node<TState, TAction>> GetPathFromRoot()
        {
            var path = new List<Node<TState, TAction>>();
            var current = this;
            while (current.Parent != null)
            {
                path.Insert(0, current);
                current = current.Parent;
            }

            path.Insert(0, current);
            return path;
        }
    }
}
