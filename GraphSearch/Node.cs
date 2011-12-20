using System.Collections.Generic;

namespace GraphSearch
{
    public class Node
    {
        public Node(string name)
        {
            Name = name;
            Edges = new List<Edge>();
        }

        public string Name { get; private set; }
        public List<Edge> Edges { get; private set; }
    }
}
