using System;

namespace _420J13AS_final
{
    class Program
    {
        static void Main(string[] args)
        {
            Procedure1();
            Procedure2();
            //Procedure3();
            //Procedure4();
            Procedure5();
        }

        static void Procedure1()
        {
            Console.WriteLine("Procedure1_______________________________");
            var bst = new BinarySearchTree<int>();
            bst.Insert(4);
            bst.Insert(2);
            bst.Insert(6);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(5);
            bst.Insert(7);
            Console.WriteLine("Expected output: 1,");
            Console.WriteLine(bst.Predecessor(bst.Search(2)).key);
            Console.WriteLine("Expected output: 6,");
            Console.WriteLine(bst.Predecessor(bst.Search(7)).key);
            Console.WriteLine();
        }

        static void Procedure2()
        {
            Console.WriteLine("Procedure2_______________________________");
            var rb = new RedBlackTree<int>();
            rb.Insert(41);
            rb.Insert(38);
            rb.Insert(31);
            rb.Insert(12);
            rb.Insert(19);
            rb.Insert(8);
            rb.Delete(rb.Search(38));
            rb.Delete(rb.Search(41));
            rb.Delete(rb.Search(31));
            rb.Delete(rb.Search(12));
            rb.Delete(rb.Search(19));
            Console.WriteLine("Expected output: 8,");
            rb.InorderTreeWalk();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Procedure3()
        {
            Console.WriteLine("Procedure3_______________________________");
            var graph = new ListGraph('u', 'v', 'w', 'x', 'y', 'z');
            graph.AddEdge('u', 'v');
            graph.AddEdge('u', 'x');
            graph.AddEdge('v', 'y');
            graph.AddEdge('w', 'y');
            graph.AddEdge('w', 'z');
            graph.AddEdge('x', 'v');
            graph.AddEdge('y', 'x');
            graph.AddEdge('z', 'z');

            graph.DepthFirstSearch();
            Console.WriteLine("Expected output: Vertex u: 1/8");
            graph.PrintTimestamp('u');
            Console.WriteLine("Expected output: Vertex w: 9/12");
            graph.PrintTimestamp('w');
            Console.WriteLine("Expected output: Vertex z: 10/11");
            graph.PrintTimestamp('z');
            Console.WriteLine();
        }

        static void Procedure4()
        {
            Console.WriteLine("Procedure4_______________________________");
            var graph = new MatrixGraph('s', 't', 'x', 'y', 'z');
            graph.AddEdge('s', 't', 10);
            graph.AddEdge('s', 'y', 5);
            graph.AddEdge('t', 'x', 1);
            graph.AddEdge('t', 'y', 2);
            graph.AddEdge('x', 'z', 4);
            graph.AddEdge('y', 't', 3);
            graph.AddEdge('y', 'x', 9);
            graph.AddEdge('y', 'z', 2);
            graph.AddEdge('z', 's', 7);
            graph.AddEdge('z', 'x', 6);

            graph.Dijkstra('s');
            Console.WriteLine("Expected output: ->s->y->t->x");
            graph.PrintPath('s', 'x');
            Console.WriteLine("Expected output: ->s->y->z");
            graph.PrintPath('s', 'z');
            Console.WriteLine();
        }

        static void Procedure5()
        {
            Console.WriteLine("Procedure5_______________________________");
            Console.WriteLine("Expected output: Sunny");
            Console.WriteLine(Meteo.Predict(Weather.Sunny));
            Console.WriteLine("Expected output: Rainy");
            Console.WriteLine(Meteo.Predict(Weather.Cloudy));
            Console.WriteLine("Expected output: Cloudy");
            Console.WriteLine(Meteo.Predict(Weather.Rainy));
            Console.WriteLine();
        }
    }
}
