using System;

namespace _420J13AS_final
{
    class BinarySearchTree<T> where T : IComparable
    {
        BinarySearchTreeNode<T> root;

        public BinarySearchTreeNode<T> Predecessor(BinarySearchTreeNode<T> x)
        {
            // Implement this
            if (x.left != null)
            {
                return Maximum(x.left);
            }
            var y = x.p;
            while(y!=null && x == y.left)
            {
                x = y;
                y = y.p;
                return y;
            }
            return y;
        }

        BinarySearchTreeNode<T> Maximum(BinarySearchTreeNode<T> x)
        {
            while (x.right != null)
            {
                x = x.right;
            }
            return x;
        }

        public BinarySearchTreeNode<T> Search(T k)
        {
            return Search(root, k);
        }

        BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> x, T k)
        {
            if (x == null || k.CompareTo(x.key) == 0)
            {
                return x;
            }
            if (k.CompareTo(x.key) < 0)
            {
                return Search(x.left, k);
            }
            else
            {
                return Search(x.right, k);
            }
        }



        public void Insert(T k)
        {
            BinarySearchTreeNode<T> z = new BinarySearchTreeNode<T>(k);
            BinarySearchTreeNode<T> y = null;
            BinarySearchTreeNode<T> x = root;

            while (x != null)
            {
                y = x;
                if (z.key.CompareTo(x.key) < 0)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;

                }
            }
            z.p = y;
            if (y == null)
            {
                root = z; // tree T was empty
            }
            else if (z.key.CompareTo(y.key) < 0)
            {
                y.left = z;
            }
            else
            {
                y.right = z;
            }
        }
    }
}
