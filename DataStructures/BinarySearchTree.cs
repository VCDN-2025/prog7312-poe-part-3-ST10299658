using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node Left;
            public Node Right;

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public void Insert(T value)
        {
            root = InsertRecursive(root, value);
        }

        private Node InsertRecursive(Node node, T value)
        {
            if (node == null)
                return new Node(value);

            if (value.CompareTo(node.Data) < 0)
                node.Left = InsertRecursive(node.Left, value);
            else if (value.CompareTo(node.Data) > 0)
                node.Right = InsertRecursive(node.Right, value);

            return node;
        }

        public bool Search(T value)
        {
            return SearchRecursive(root, value);
        }

        private bool SearchRecursive(Node node, T value)
        {
            if (node == null)
                return false;

            int comparison = value.CompareTo(node.Data);
            if (comparison == 0)
                return true;
            else if (comparison < 0)
                return SearchRecursive(node.Left, value);
            else
                return SearchRecursive(node.Right, value);
        }

        // ✅ The InOrder() method your form expects
        public List<T> InOrder()
        {
            List<T> result = new List<T>();
            InOrderTraversal(root, result);
            return result;
        }

        private void InOrderTraversal(Node node, List<T> result)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left, result);
            result.Add(node.Data);
            InOrderTraversal(node.Right, result);
        }

        // Optional: for completeness
        public List<T> PreOrder()
        {
            List<T> result = new List<T>();
            PreOrderTraversal(root, result);
            return result;
        }

        private void PreOrderTraversal(Node node, List<T> result)
        {
            if (node == null)
                return;

            result.Add(node.Data);
            PreOrderTraversal(node.Left, result);
            PreOrderTraversal(node.Right, result);
        }

        public List<T> PostOrder()
        {
            List<T> result = new List<T>();
            PostOrderTraversal(root, result);
            return result;
        }

        private void PostOrderTraversal(Node node, List<T> result)
        {
            if (node == null)
                return;

            PostOrderTraversal(node.Left, result);
            PostOrderTraversal(node.Right, result);
            result.Add(node.Data);
        }
    }
}
