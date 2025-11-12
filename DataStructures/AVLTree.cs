using System;

namespace MunicipalServicesApp.DataStructures
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Data;
            public Node Left;
            public Node Right;
            public int Height;

            public Node(T data)
            {
                Data = data;
                Height = 1;
            }
        }

        public Node Root;

        private int Height(Node node) => node?.Height ?? 0;

        private int GetBalance(Node node) => node == null ? 0 : Height(node.Left) - Height(node.Right);

        private Node RotateRight(Node y)
        {
            var x = y.Left;
            var T2 = x.Right;
            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private Node RotateLeft(Node x)
        {
            var y = x.Right;
            var T2 = y.Left;
            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public void Insert(T data)
        {
            Root = InsertRec(Root, data);
        }

        private Node InsertRec(Node node, T data)
        {
            if (node == null)
                return new Node(data);

            if (data.CompareTo(node.Data) < 0)
                node.Left = InsertRec(node.Left, data);
            else if (data.CompareTo(node.Data) > 0)
                node.Right = InsertRec(node.Right, data);
            else
                return node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

            // Left Heavy
            if (balance > 1 && data.CompareTo(node.Left.Data) < 0)
                return RotateRight(node);

            // Right Heavy
            if (balance < -1 && data.CompareTo(node.Right.Data) > 0)
                return RotateLeft(node);

            // Left Right
            if (balance > 1 && data.CompareTo(node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right Left
            if (balance < -1 && data.CompareTo(node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }
    }
}
