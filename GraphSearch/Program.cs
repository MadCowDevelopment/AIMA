
using System;
using System.Linq;

namespace GraphSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = MapCreator.CreateMap();
            var algo = new GraphSearchAlgorithm(map);

            var start = map.Nodes.FirstOrDefault(p => p.Name == "Arad");
            var goal =  map.Nodes.FirstOrDefault(p => p.Name == "Bucharest");
            var result = algo.SearchPath(start, goal);

            foreach (var node in result)
            {
                Console.WriteLine(node + " -> ");
            }
        }
    }
}
