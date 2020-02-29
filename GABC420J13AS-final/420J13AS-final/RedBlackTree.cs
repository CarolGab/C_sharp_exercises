using System;

namespace _420J13AS_final
{
    class RedBlackTree<T> where T : IComparable
    {
        RedBlackTreeNode<T> root;
        readonly RedBlackTreeNode<T> nil = new RedBlackTreeNode<T>(default(T))
        {
            color = Color.Black
        };

        public RedBlackTree()
        {
            root = nil;
        }

        public void Delete(RedBlackTreeNode<T> z)
        {
            var y = z;
            var x = z;

            var yOriginalColor = y.color;
            if (z.left == nil)
            {
                x = z.right;
                Transplant(z, z.right);
            }
            else if (z.right == nil)
            {
                x = z.left;
                Transplant(z, z.left);
            }
            else
            {
                // Implement this
                y = Minimum(z.right);
                yOriginalColor = y.color;
                x = y.right;
                if (y.p == z)
                {
                    x.p = y;
                }
                else
                {
                    Transplant(y, y.right);
                    y.right = z.right;
                    y.right.p = y;                    
                }
                Transplant(z, y);
                y.left = z.left;
                y.left.p = y;
                y.color = z.color;
            }

            if (yOriginalColor == Color.Black)
            {
                DeleteFixup(x);
            }
        }

        void Transplant(RedBlackTreeNode<T> u, RedBlackTreeNode<T> v)
        {
            if (u.p == nil)
            {
                root = v;
            }
            else if (u == u.p.left)
            {
                u.p.left = v;
            }
            else
            {
                u.p.right = v;
            }
            v.p = u.p;
        }

        RedBlackTreeNode<T> Minimum(RedBlackTreeNode<T> x)
        {
            while (x.left != nil)
            {
                x = x.left;
            }
            return x;
        }

        void DeleteFixup(RedBlackTreeNode<T> x)
        {
            while (x != root && x.color == Color.Black)
            {
                if (x == x.p.left)
                {
                    var w = x.p.right;
                    if (w.color == Color.Red)
                    {
                        w.color = Color.Black;
                        x.p.color = Color.Red;
                        LeftRotate(x.p);
                        w = x.p.right;
                    }
                    if (w.left.color == Color.Black && w.right.color == Color.Black)
                    {
                        w.color = Color.Red;
                        x = x.p;
                    }
                    else
                    {
                        if (w.right.color == Color.Black)
                        {
                            w.left.color = Color.Black;
                            w.color = Color.Red;
                            RightRotate(w);
                            w = x.p.right;
                        }
                        w.color = x.p.color;
                        x.p.color = Color.Black;
                        w.right.color = Color.Black;
                        LeftRotate(x.p);
                        x = root;
                    }
                }
                else
                {
                    var w = x.p.left;
                    if (w.color == Color.Red)
                    {
                        w.color = Color.Black;
                        x.p.color = Color.Red;
                        RightRotate(x.p);
                        w = x.p.left;
                    }
                    if (w.right.color == Color.Black && w.left.color == Color.Black)
                    {
                        w.color = Color.Red;
                        x = x.p;
                    }
                    else
                    {
                        if (w.left.color == Color.Black)
                        {
                            w.right.color = Color.Black;
                            w.color = Color.Red;
                            LeftRotate(w);
                            w = x.p.right;
                        }
                        w.color = x.p.color;
                        x.p.color = Color.Black;
                        w.left.color = Color.Black;
                        RightRotate(x.p);
                        x = root;
                    }
                }
            }
            x.color = Color.Black;
        }

        public void InorderTreeWalk()
        {
            InorderTreeWalk(root);
        }

        void InorderTreeWalk(RedBlackTreeNode<T> x)
        {
            if (x != nil)
            {
                InorderTreeWalk(x.left);
                Console.Write($"{x.key},");
                InorderTreeWalk(x.right);
            }
        }

        public RedBlackTreeNode<T> Search(T k)
        {
            return Search(root, k);
        }

        RedBlackTreeNode<T> Search(RedBlackTreeNode<T> x, T k)
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

        public void LeftRotate(RedBlackTreeNode<T> x)
        {
            var y = x.right;
            x.right = y.left;
            if (y.left != nil)
            {
                y.left.p = x;
            }
            y.p = x.p;
            if (x.p == nil)
            {
                root = y;
            }
            else if (x == x.p.left)
            {
                x.p.left = y;
            }
            else
            {
                x.p.right = y;
            }
            y.left = x;
            x.p = y;
        }

        public void RightRotate(RedBlackTreeNode<T> x)
        {
            var y = x.left;
            x.left = y.right;
            if (y.right != nil)
            {
                y.right.p = x;
            }
            y.p = x.p;
            if (x.p == nil)
            {
                root = y;
            }
            else if (x == x.p.right)
            {
                x.p.right = y;
            }
            else
            {
                x.p.left = y;
            }
            y.right = x;
            x.p = y;
        }

        public void Insert(T k)
        {
            var z = new RedBlackTreeNode<T>(k);
            var y = nil;
            var x = root;

            while (x != nil)
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
            if (y == nil)
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
            z.left = nil;
            z.right = nil;
            InsertFixup(z);
        }

        void InsertFixup(RedBlackTreeNode<T> z)
        {
            while (z.p.color == Color.Red)
            {
                if (z.p == z.p.p.left)
                {
                    var y = z.p.p.right;
                    if (y.color == Color.Red)
                    {
                        z.p.color = Color.Black; // case 1
                        y.color = Color.Black; // case 1
                        z.p.p.color = Color.Red; // case 1
                        z = z.p.p; // case 1
                    }
                    else
                    {
                        if (z == z.p.right)
                        {
                            z = z.p; // case 2
                            LeftRotate(z); // case 2
                        }
                        z.p.color = Color.Black; // case 3
                        z.p.p.color = Color.Red; // case 3
                        RightRotate(z.p.p); // case 3
                    }
                }
                else
                {
                    var y = z.p.p.left;
                    if (y.color == Color.Red)
                    {
                        z.p.color = Color.Black; // case 1
                        y.color = Color.Black; // case 1
                        z.p.p.color = Color.Red; // case 1
                        z = z.p.p; // case 1
                    }
                    else
                    {
                        if (z == z.p.left)
                        {
                            z = z.p; // case 2
                            RightRotate(z); // case 2
                        }
                        z.p.color = Color.Black; // case 3
                        z.p.p.color = Color.Red; // case 3
                        LeftRotate(z.p.p); // case 3
                    }
                }
            }
            root.color = Color.Black;
        }
    }
}
