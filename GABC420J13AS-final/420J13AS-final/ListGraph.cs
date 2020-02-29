using System;
using System.Collections.Generic;

namespace _420J13AS_final
{
    class ListGraph : Graph
    {
        readonly List<AdjacentVertex>[] adjacencyList;

        public ListGraph(params char[] vertexKeys) : base(vertexKeys)
        {
            adjacencyList = new List<AdjacentVertex>[maxChar - minChar + 1];
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                adjacencyList[i] = new List<AdjacentVertex>();
            }
        }

        public override void AddEdge(char sourceKey, char destinationKey, int weight = 1)
        {
            Vertex destination = vertices.Find(v => v.key == destinationKey);
            adjacencyList[sourceKey - minChar].Add(new AdjacentVertex(destination, weight));
        }

        public override void DepthFirstSearch()
        {
            // Implement this

        }

        void DepthFirstSearchVisit(Vertex u)
        {
            time++;
            u.discoveryTime = time;
            u.color = Color.Grey;

            foreach (AdjacentVertex neighbor in adjacencyList[u.key - minChar])
            {
                var v = neighbor.vertex;

                if (v.color == Color.White)
                {
                    v.predecessor = u;
                    DepthFirstSearchVisit(v);
                }
            }

            u.color = Color.Black;
            time++;
            u.finishingTime = time;
        }

        public override void BreadthFirstSearch(char sourceKey)
        {
            throw new NotImplementedException();
        }

        public override bool BellmanFord(char sourceKey)
        {
            throw new NotImplementedException();
        }

        public override void Dijkstra(char sourceKey)
        {
            throw new NotImplementedException();
        }
    }
}
