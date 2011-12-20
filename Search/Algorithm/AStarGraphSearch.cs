using System;
using System.Collections.Generic;
using System.Linq;

using Search.Framework;
using Search.Types;

namespace Search.Algorithm
{
    public class AStarGraphSearch<TState, TAction> : IGraphSearch<TState, TAction>
    {
        private readonly HeuristicFunction<TState> _heuristic;

        public AStarGraphSearch(HeuristicFunction<TState> heuristic)
        {
            _heuristic = heuristic;
        }

        public List<Node<TState, TAction>> Search(Problem<TState, TAction> problem)
        {
            PriorityQueue<Node<TState, TAction>> frontier = new PriorityQueue<Node<TState, TAction>>();
            HashSet<Node<TState, TAction>> explored = new HashSet<Node<TState, TAction>>();

            var root = new Node<TState, TAction>(problem.InitalState);
            var cost = root.TotalCost + _heuristic.Cost(problem.InitalState);
            frontier.Enqueue(root, cost);

            for (; ; )
            {
                if (frontier.Count == 0) throw new InvalidOperationException("Frontier is empty.");
                var leaf = frontier.Dequeue();
                Console.WriteLine("Leaf:\n" + leaf.State + "\nDepth: " + leaf.Depth);
                if (problem.GoalTest.IsGoal(leaf.State)) return leaf.GetPathFromRoot();
                explored.Add(leaf);

                var children = ExpandNode(leaf, problem);
                foreach (var child in children)
                {
                    var child1 = child;
                    if (!frontier.Any(p => p.State.Equals(child1.State)) && !explored.Any(p => p.State.Equals(child1.State)))
                    {
                        cost = child.TotalCost + _heuristic.Cost(child.State);
                        frontier.Enqueue(child, cost);
                    }
                }
            }
        }

        public List<Node<TState, TAction>> ExpandNode(Node<TState, TAction> node, Problem<TState, TAction> problem)
        {
            var childNodes = new List<Node<TState, TAction>>();

            var actions = problem.ActionFunction.Actions(node.State);
            foreach (var action in actions)
            {
                var state = problem.ResultFunction.Result(node.State, action);
                var cost = problem.StepCost.Cost(node.State, action);
                var childNode = new Node<TState, TAction>(state, node, action, cost);
                childNodes.Add(childNode);
            }

            return childNodes;
        }
    }
}
