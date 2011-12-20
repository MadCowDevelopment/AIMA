
namespace GraphSearch
{
    public static class MapCreator
    {
        public static Map CreateMap()
        {
            var map = new Map();

            var oradea = new Node("Oradea");
            var zerind = new Node("Zerind");
            var arad = new Node("Arad");
            var timisoara = new Node("Timisoara");
            var lugoj = new Node("Lugoj");
            var mehadia = new Node("Mehadia");
            var drobeta = new Node("Drobeta");
            var sibiu = new Node("Sibiu");
            var rimnicuVilcea = new Node("Rimnicu Vilcea");
            var craiova = new Node("Craiova");
            var fagaras = new Node("Fagaras");
            var pitesti = new Node("Pitesti");
            var bucharest = new Node("Bucharest");
            var giurgiu = new Node("Giurgiu");
            var urziceni = new Node("Urziceni");
            var vaslui = new Node("Vaslui");
            var iasi = new Node("Iasi");
            var neamt = new Node("Neamt");
            var hirsova = new Node("Hirsova");
            var eforie = new Node("Eforie");

            map.Nodes.Add(oradea);
            map.Nodes.Add(zerind);
            map.Nodes.Add(arad);
            map.Nodes.Add(timisoara);
            map.Nodes.Add(lugoj);
            map.Nodes.Add(mehadia);
            map.Nodes.Add(drobeta);
            map.Nodes.Add(sibiu);
            map.Nodes.Add(rimnicuVilcea);
            map.Nodes.Add(craiova);
            map.Nodes.Add(fagaras);
            map.Nodes.Add(pitesti);
            map.Nodes.Add(bucharest);
            map.Nodes.Add(giurgiu);
            map.Nodes.Add(urziceni);
            map.Nodes.Add(vaslui);
            map.Nodes.Add(iasi);
            map.Nodes.Add(neamt);
            map.Nodes.Add(hirsova);
            map.Nodes.Add(eforie);

            oradea.Edges.Add(new Edge(zerind, 71));
            oradea.Edges.Add(new Edge(sibiu, 151));

            zerind.Edges.Add(new Edge(oradea, 71));
            zerind.Edges.Add(new Edge(arad, 75));

            arad.Edges.Add(new Edge(zerind, 75));
            arad.Edges.Add(new Edge(sibiu, 140));
            arad.Edges.Add(new Edge(timisoara, 118));

            timisoara.Edges.Add(new Edge(arad, 118));
            timisoara.Edges.Add(new Edge(lugoj, 111));

            lugoj.Edges.Add(new Edge(timisoara, 111));
            lugoj.Edges.Add(new Edge(mehadia, 70));

            mehadia.Edges.Add(new Edge(lugoj, 70));
            mehadia.Edges.Add(new Edge(drobeta, 75));

            drobeta.Edges.Add(new Edge(mehadia, 75));
            drobeta.Edges.Add(new Edge(craiova, 120));

            craiova.Edges.Add(new Edge(drobeta, 120));
            craiova.Edges.Add(new Edge(rimnicuVilcea, 146));
            craiova.Edges.Add(new Edge(pitesti, 138));

            sibiu.Edges.Add(new Edge(oradea, 151));
            sibiu.Edges.Add(new Edge(arad, 140));
            sibiu.Edges.Add(new Edge(fagaras, 99));
            sibiu.Edges.Add(new Edge(rimnicuVilcea, 80));

            rimnicuVilcea.Edges.Add(new Edge(sibiu, 80));
            rimnicuVilcea.Edges.Add(new Edge(pitesti, 97));
            rimnicuVilcea.Edges.Add(new Edge(craiova, 146));

            fagaras.Edges.Add(new Edge(sibiu, 99));
            fagaras.Edges.Add(new Edge(bucharest, 211));

            pitesti.Edges.Add(new Edge(rimnicuVilcea, 97));
            pitesti.Edges.Add(new Edge(craiova, 138));
            pitesti.Edges.Add(new Edge(bucharest, 101));

            bucharest.Edges.Add(new Edge(fagaras, 211));
            bucharest.Edges.Add(new Edge(pitesti, 101));
            bucharest.Edges.Add(new Edge(giurgiu, 90));
            bucharest.Edges.Add(new Edge(urziceni, 85));

            giurgiu.Edges.Add(new Edge(bucharest, 90));

            urziceni.Edges.Add(new Edge(bucharest, 85));
            urziceni.Edges.Add(new Edge(vaslui, 142));
            urziceni.Edges.Add(new Edge(hirsova, 98));

            vaslui.Edges.Add(new Edge(urziceni, 142));
            vaslui.Edges.Add(new Edge(iasi, 92));

            iasi.Edges.Add(new Edge(vaslui, 92));
            iasi.Edges.Add(new Edge(neamt, 87));

            neamt.Edges.Add(new Edge(iasi, 87));

            hirsova.Edges.Add(new Edge(urziceni, 98));
            hirsova.Edges.Add(new Edge(eforie, 86));

            eforie.Edges.Add(new Edge(hirsova, 86));

            return map;
        }
    }
}
