using System;
using Vakor.DataStructures.DoubleLinkedLists;

namespace Vakor.DataStructures.Stacks
{
    public class LinkedListStack<T> : IStack<T>
    {
        public int Length => _linkedList.Length;

        private readonly IDoubleLinkedList<T> _linkedList;

        public LinkedListStack()
        {
            _linkedList = new DoubleLinkedList<T>();
        }

        public void Push(T element)
        {
            _linkedList.Insert(element);
        }

        public T Pop()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T element = _linkedList.Last.Data;
            _linkedList.RemoveAt(_linkedList.Length - 1);
            return element;
        }
        
        public void Clear()
        {
            _linkedList.Clear();
        }
    }
}