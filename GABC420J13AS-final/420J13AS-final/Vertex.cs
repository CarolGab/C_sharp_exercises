using System;

namespace _420J13AS_final
{
    class Vertex : IComparable
    {
        public Color color;
        public char key;
        public int distance;
        public Vertex predecessor;

        public int discoveryTime;
        public int finishingTime;

        public Vertex(char key)
        {
            this.key = key;
        }

        public int CompareTo(object obj)
        {
            if (obj is Vertex other)
            {
                return distance.CompareTo(other.distance);
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return key.ToString();
        }
    }
}
