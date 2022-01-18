using System;
using Vakor.DataStructures.DoubleLinkedLists;

namespace Vakor.DataStructures.Queues
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        public int Length => _linkedList.Length;

        private readonly IDoubleLinkedList<T> _linkedList;

        public LinkedListQueue()
        {
            _linkedList = new DoubleLinkedList<T>();
        }

        public void Enqueue(T element)
        {
            _linkedList.Insert(element);
        }

        public T Dequeue()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T element = _linkedList.First.Data;
            _linkedList.RemoveAt(0);

            return element;
        }

        public void Clear()
        {
            _linkedList.Clear();
        }
    }
}