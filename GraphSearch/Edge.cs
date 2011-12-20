
namespace GraphSearch
{
    public class Edge
    {
        public Edge(Node node, int distance)
        {
            Distance = distance;
            Node = node;
        }

        public int Distance { get; private set; }
        public Node Node { get; private set; }
    }
}
