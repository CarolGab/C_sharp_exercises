using System;

namespace _420J13AS_final
{
    class MatrixGraph : Graph
    {
        readonly int[,] adjacencyMatrix;

        public MatrixGraph(params char[] vertexKeys) : base(vertexKeys)
        {
            int n = maxChar - minChar + 1;
            adjacencyMatrix = new int[n, n];
        }

        public override void AddEdge(char sourceKey, char destinationKey, int weight = 1)
        {
            adjacencyMatrix[sourceKey - minChar, destinationKey - minChar] = weight;
        }

        public override void Dijkstra(char sourceKey)
        {
            // Implement this
        }

        void InitializeSingleSource(Vertex s)
        {
            foreach (var v in vertices)
            {
                v.distance = int.MaxValue;
                v.predecessor = null;
            }
            s.distance = 0;
        }

        void Relax(Vertex u, Vertex v)
        {
            int weight = adjacencyMatrix[u.key - minChar, v.key - minChar];

            int before = v.distance;
            if (v.distance > u.distance + weight)
            {
                v.distance = u.distance + weight;
                v.predecessor = u;
            }
        }

        public override void BreadthFirstSearch(char sourceKey)
        {
            throw new NotImplementedException();
        }

        public override void DepthFirstSearch()
        {
            throw new NotImplementedException();
        }

        public override bool BellmanFord(char sourceKey)
        {
            throw new NotImplementedException();
        }
    }
}
