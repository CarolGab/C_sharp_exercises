using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletonMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                Random random1 = new Random();
                int v1 = random1.Next(0, 10);
                Console.WriteLine("Random 1: " + v1);
            }
            Console.WriteLine("Random Singleton: ");
            for (int i = 0; i < 5; i++)
            {
                Random random1 = RandomGenerator.GetInstance();
                int v1 = random1.Next(0, 10);
                Console.WriteLine("Random 1: " +v1);
            }
        }
    }

}
