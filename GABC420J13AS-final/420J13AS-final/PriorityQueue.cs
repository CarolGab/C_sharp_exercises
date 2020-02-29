using System.Collections.Generic;

namespace _420J13AS_final
{
    class PriorityQueue<T> : List<T>
    {
        public T ExtractMin()
        {
            Sort();
            T result = this[0];
            RemoveAt(0);
            return result;
        }
    }
}
