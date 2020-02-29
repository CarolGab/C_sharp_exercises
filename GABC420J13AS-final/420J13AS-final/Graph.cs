using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420J13AS_final
{
    abstract class Graph
    {
        protected List<Vertex> vertices = new List<Vertex>();
        protected readonly int minChar = int.MaxValue;
        protected readonly int maxChar = int.MinValue;
        protected int time;

        abstract public void AddEdge(char sourceKey, char destinationKey, int weight = 1);
        abstract public void BreadthFirstSearch(char sourceKey);
        abstract public void DepthFirstSearch();
        abstract public bool BellmanFord(char sourceKey);
        abstract public void Dijkstra(char sourceKey);

        public Graph(params char[] vertexKeys)
        {
            foreach (char k in vertexKeys)
            {
                vertices.Add(new Vertex(k));

                if (k < minChar)
                {
                    minChar = k;
                }
                if (k > maxChar)
                {
                    maxChar = k;
                }
            }
        }

        public void PrintPath(char sourceKey, char destinationKey)
        {
            Vertex s = vertices.Find(v1 => v1.key == sourceKey);
            Vertex v = vertices.Find(v2 => v2.key == destinationKey);
            PrintPath(s, v);
            Console.WriteLine();
        }

        void PrintPath(Vertex s, Vertex v)
        {
            if (v == s)
            {
                Console.Write($"->{s}");
            }
            else if (v.predecessor == null)
            {
                Console.Write($"no path from {s} to {v} exists");
            }
            else
            {
                PrintPath(s, v.predecessor);
                Console.Write($"->{v}");
            }
        }

        public void PrintTimestamp(char k)
        {
            var v = vertices.Find(vertex => vertex.key == k);
            Console.WriteLine($"Vertex {v.key}: {v.discoveryTime}/{v.finishingTime}");
        }

        public void PrintTimestamps()
        {
            foreach (Vertex v in vertices)
            {
                Console.WriteLine($"Vertex {v.key}: {v.discoveryTime}/{v.finishingTime}");
            }
        }

        protected void InitializeSingleSource(char sourceKey)
        {
            foreach (var v in vertices)
            {
                v.distance = int.MaxValue;
                v.predecessor = null;
            }
            vertices.Find(v => v.key == sourceKey).distance = 0;
        }
    }
}
