using System;

namespace DoubleLinkedList
{
    public class Node<T>
    {
        public T data { get; private set; }
        public Node<T> next;
        public Node<T> previous;

        public Node(T data)
        {
            this.data = data;
        }
    }
}
