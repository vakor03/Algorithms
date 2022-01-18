using System;

namespace Vakor.DataStructures.Queues
{
    public class ArrayQueue<T> : IQueue<T>
    {
        public int Length { get; private set; }

        private T[] _queueArray;
        private int _queuePointer;

        public ArrayQueue()
        {
            Length = 0;
            _queueArray = new T[2];
            _queuePointer = 0;
        }

        public void Enqueue(T element)
        {
            _queueArray[_queuePointer + Length] = element;
            Length++;

            if (_queuePointer + Length >= _queueArray.Length)
            {
                ResizeArray();
            }
        }

        public T Dequeue()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            T element = _queueArray[_queuePointer++];
            Length--;
            return element;
        }

        public void Clear()
        {
            _queuePointer = 0;
            Length = 0;
        }

        private void ResizeArray()
        {
            T[] newArray = new T[_queueArray.Length * 2];
            
            for (int i = 0; i < Length; i++)
            {
                newArray[i] = _queueArray[i+_queuePointer];
            }

            _queuePointer = 0;
            _queueArray = newArray;
        }
    }
}