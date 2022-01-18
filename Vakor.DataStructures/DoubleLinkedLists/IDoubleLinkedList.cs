using Vakor.DataStructures.DoubleLinkedLists.DoubleLinkedNodes;

namespace Vakor.DataStructures.DoubleLinkedLists
{
    public interface IDoubleLinkedList<T>
    {
        IDoubleLinkedNode<T> this[int id] { get;}

        IDoubleLinkedNode<T> First { get; }
        IDoubleLinkedNode<T> Last { get; }

        int Length { get; }
        void Insert(T element);
        void InsertAt(T element, int index);

        void Remove(T element);
        void RemoveAt(int index);

        void Clean();

        IDoubleLinkedNode<T> Search(T searchElement);
    }
}