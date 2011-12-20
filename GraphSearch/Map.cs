using System.Collections.Generic;

namespace GraphSearch
{
    public class Map
    {
        public Map()
        {
            Nodes = new List<Node>();
        }

        public List<Node> Nodes { get; private set; }
    }
}
