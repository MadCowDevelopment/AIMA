using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    public class GraphSearchAlgorithm
    {
        private readonly Map _map;

        public GraphSearchAlgorithm(Map map)
        {
            _map = map;
        }

        public List<Node> SearchPath(Node start, Node goal)
        {
            var result = new List<Node>();
            var frontier = InitializeFrontier(start);
            var explored = new List<Node>();
            var root = new GraphNode(start, null);

            while (frontier.Count > 0)
            {
                var curr = frontier.Dequeue();
                //if (curr == goal) return solution;
                explored.Add(curr);
                if(!frontier.Contains(curr) && !explored.Contains(curr))
                {
                    foreach (var edge in curr.Edges)
                    {
                        frontier.Enqueue(edge.Node);
                    }
                }
            }

            return null;
        }

        private Queue<Node> InitializeFrontier(Node start)
        {
            var frontier = new Queue<Node>();
            foreach (var edge in start.Edges)
            {
                frontier.Enqueue(edge.Node);
            }

            return frontier;
        }
    }

    public class Solution
    {
        
    }

    public class GraphNode
    {
        public GraphNode(Node node, Node parent)
        {
            Node = node;
            Parent = parent;
        }

        public Node Node { get; private set; }
        public Node Parent { get; private set; }
    }
}
