using Vakor.DataStructures.LinkedLists.LinkedNodes;

namespace Vakor.DataStructures.LinkedLists
{
    public interface ILinkedList<T>
    {
        ILinkedNode<T> this[int id] { get; }

        ILinkedNode<T> First { get; }

        ILinkedNode<T> Last { get; }

        int Length { get; }

        void Insert(T element);

        void InsertAt(T element, int index);

        void Remove(T element);

        void RemoveAt(int index);

        void Clear();

        ILinkedNode<T> Search(T searchElement);
    }
}