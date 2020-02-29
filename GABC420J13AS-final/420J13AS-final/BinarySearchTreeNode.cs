using System;

namespace _420J13AS_final
{
    class BinarySearchTreeNode<T> where T : IComparable
    {
        public T key;
        public BinarySearchTreeNode<T> p;
        public BinarySearchTreeNode<T> left;
        public BinarySearchTreeNode<T> right;

        public BinarySearchTreeNode(T key)
        {
            this.key = key;
        }
    }
}
