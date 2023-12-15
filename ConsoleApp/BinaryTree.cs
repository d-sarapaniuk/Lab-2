using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class BinaryTree<T>: IEnumerable<Node<T>> where T: IComparable<T>
    {      
        public Node<T>? Root { get; private set; }
        public BinaryTree() 
        {
            Root = null;
        }
        public void Insert(T data)
        {
            Root = InsertRecursion(Root, data);
        }
        private Node<T> InsertRecursion(Node<T>? root, T data)
        {
            if (root == null) return new Node<T>(data);
            int compared = data.CompareTo(root.Data);

            if (compared < 0) root.Left = InsertRecursion(root.Left, data);
            else if (compared > 0) root.Right = InsertRecursion(root.Right, data);
            return root;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return new TreeEnumerator(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class TreeEnumerator : IEnumerator<Node<T>>  // postorder
        {
            private Node<T> Current;
            private Queue<Node<T>> Queue;
            public TreeEnumerator(Node<T> root) 
            { 
                Current = root; 
                Queue = new Queue<Node<T>>();
                FillQueue(Current);
            }
            
            private void FillQueue(Node<T>? current)
            {
                if (current == null) return;
                FillQueue(current.Left);
                FillQueue(current.Right);
                Queue.Enqueue(current);
            }

            object IEnumerator.Current => Current;

            Node<T> IEnumerator<Node<T>>.Current => Current;

            public bool MoveNext()
            {
                if (Queue.Count == 0) return false;
                Current = Queue.Dequeue();
                return true;
            }
            public void Dispose() { }
            public void Reset() { }
        }
    }
    internal class Node<T>: IComparable<Node<T>> where T: IComparable<T>
    {
        public T Data { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        public Node(T data) 
        { 
            Data = data;
            Left = null;
            Right = null;
        }

        public int CompareTo(Node<T>? other)
        {
            if (other == null) return 1;
            return Data.CompareTo(other.Data);
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
