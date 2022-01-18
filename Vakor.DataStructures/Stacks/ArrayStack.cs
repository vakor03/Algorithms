using System;

namespace Vakor.DataStructures.Stacks
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] _stackArray;
        private int _stackPointer;

        public int Length => _stackPointer;


        public ArrayStack()
        {
            _stackArray = new T[2];
            _stackPointer = 0;
        }

        public void Push(T element)
        {
            _stackArray[_stackPointer] = element;
            if (++_stackPointer >= _stackArray.Length)
            {
                ResizeArray();
            }
        }

        public T Pop()
        {
            if (_stackPointer == 0)
            {
                throw new IndexOutOfRangeException("Stack is empty");
            }

            return _stackArray[--_stackPointer];
        }

        public void Clear()
        {
            _stackArray = new T[2];
            _stackPointer = 0;
        }

        /// <summary>
        /// Resizes stack array if stack os overflown
        /// </summary>
        private void ResizeArray()
        {
            T[] newArray = new T[_stackArray.Length * 2];
            for (int i = 0; i < _stackArray.Length; i++)
            {
                newArray[i] = _stackArray[i];
            }

            _stackArray = newArray;
        }
    }
}