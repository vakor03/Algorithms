using System;
using Vakor.DataStructures.DoubleLinkedLists.DoubleLinkedNodes;

namespace Vakor.DataStructures.DoubleLinkedLists
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        public IDoubleLinkedNode<T> this[int id] => FindNodeAt(id);

        public IDoubleLinkedNode<T> First { get; private set; }

        public IDoubleLinkedNode<T> Last { get; private set; }

        public int Length { get; private set; }

        public DoubleLinkedList()
        {
            Length = 0;
            First = null;
            Last = null;
        }

        public void Insert(T element)
        {
            IDoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>(element);

            if (First is null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.NextElement = newNode;
                newNode.PrevElement = Last;

                Last = newNode;
            }

            Length++;
        }

        public void InsertAt(T element, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == Length)
            {
                Insert(element);
                return;
            }

            IDoubleLinkedNode<T> current = FindNodeAt(index);
            IDoubleLinkedNode<T> predecessor = current.PrevElement;

            IDoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>(element);

            if (predecessor != null)
            {
                predecessor.NextElement = newNode;
                newNode.PrevElement = predecessor;
            }
            else
            {
                First = newNode;
            }

            current.PrevElement = newNode;
            newNode.NextElement = current;

            Length++;
        }

        public void Remove(T element)
        {
            IDoubleLinkedNode<T> current = Search(element);

            if (current is null)
            {
                throw new ArgumentException();
            }

            if (current == First)
            {
                First = First.NextElement;
                First.PrevElement = null;
            }
            else if (current == Last)
            {
                Last = Last.PrevElement;
                Last.NextElement = null;
            }
            else
            {
                current.PrevElement.NextElement = current.NextElement;
                current.NextElement.PrevElement = current.PrevElement;
            }

            Length--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            IDoubleLinkedNode<T> current = FindNodeAt(index);

            if (current == First)
            {
                First = First.NextElement;
                First.PrevElement = null;
            }
            else if (current == Last)
            {
                Last = Last.PrevElement;
                Last.NextElement = null;
            }
            else
            {
                current.PrevElement.NextElement = current.NextElement;
                current.NextElement.PrevElement = current.PrevElement;
            }

            Length--;
        }

        public void Clean()
        {
            First = null;
            Last = null;
            Length = 0;
        }

        public IDoubleLinkedNode<T> Search(T searchElement)
        {
            return Search(First, searchElement);
        }

        private IDoubleLinkedNode<T> Search(IDoubleLinkedNode<T> current, T searchElement)
        {
            if (current is null)
            {
                return null;
            }

            if (current.Data.Equals(searchElement))
            {
                return current;
            }

            return Search(current.NextElement, searchElement);
        }

        private IDoubleLinkedNode<T> FindNodeAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            IDoubleLinkedNode<T> current;

            if (index > Length / 2)
            {
                current = Last;
                for (int i = 0; i < Length - index - 1; i++)
                {
                    current = current.PrevElement;
                }
            }
            else
            {
                current = First;
                for (int i = 0; i < index; i++)
                {
                    current = current.NextElement;
                }
            }

            return current;
        }
    }
}