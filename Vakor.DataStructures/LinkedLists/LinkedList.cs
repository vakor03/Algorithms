namespace Vakor.DataStructures.LinkedLists
{
    using System;
    using LinkedNodes;

    public class LinkedList<T> : ILinkedList<T>
    {
        public ILinkedNode<T> this[int id] => FindNodeAt(id);

        public ILinkedNode<T> First { get; private set; }

        public ILinkedNode<T> Last { get; private set; }

        public int Length { get; private set; }

        public LinkedList()
        {
            Length = 0;
            First = null;
            Last = null;
        }

        public void Insert(T element)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(element);

            if (First is null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.NextElement = newNode;
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

            ILinkedNode<T> newNode = new LinkedNode<T>(element);
            if (index == 0)
            {
                newNode.NextElement = First;
                First = newNode;
            }
            else
            {
                ILinkedNode<T> predecessor = FindNodeAt(index - 1);
                ILinkedNode<T> current = predecessor.NextElement;

                predecessor.NextElement = newNode;
                predecessor.NextElement.NextElement = current;
            }

            Length++;
        }

        public void Remove(T element)
        {
            if (First.Data.Equals(element))
            {
                First = First.NextElement;
            }
            else
            {
                ILinkedNode<T> predecessor;
                try
                {
                    predecessor = FindPredecessor(First, element);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("List doesn't contains this value");
                }

                ILinkedNode<T> current = predecessor.NextElement;

                if (Last == current)
                {
                    Last = predecessor;
                }

                predecessor.NextElement = current.NextElement;
            }

            Length--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                First = First.NextElement;
            }
            else
            {
                ILinkedNode<T> predecessor = FindNodeAt(index - 1);
                ILinkedNode<T> current = predecessor.NextElement;

                if (Last == current)
                {
                    Last = predecessor;
                }

                predecessor.NextElement = current.NextElement;
            }

            Length--;
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Length = 0;
        }

        private ILinkedNode<T> Search(ILinkedNode<T> current, T searchElement)

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

        public ILinkedNode<T> Search(T searchElement)
        {
            return Search(First, searchElement);
        }

        private ILinkedNode<T> FindPredecessor(ILinkedNode<T> currentLinkedNode, T element)
        {
            if (currentLinkedNode?.NextElement is null)
            {
                throw new ArgumentException();
            }

            if (currentLinkedNode.NextElement.Data.Equals(element))
            {
                return currentLinkedNode;
            }

            return FindPredecessor(currentLinkedNode.NextElement, element);
        }

        private ILinkedNode<T> FindNodeAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            ILinkedNode<T> current = First;
            for (int i = 0; i < index; i++)
            {
                current = current.NextElement;
            }

            return current;
        }
    }
}