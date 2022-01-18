using Vakor.DataStructures.DoubleLinkedLists.DoubleLinkedNodes;

namespace Vakor.DataStructures.DoubleLinkedLists
{
    /// <summary>
    /// Linked list with links on the next and previous elements
    /// </summary>
    /// <typeparam name="T">any datatype</typeparam>
    public interface IDoubleLinkedList<T>
    {
        /// <summary>
        /// Gets the element on the "id" index
        /// </summary>
        /// <param name="id">index of the element</param>
        IDoubleLinkedNode<T> this[int id] { get; }

        /// <summary>
        /// Gets the first node of the linked list, null if empty
        /// </summary>
        IDoubleLinkedNode<T> First { get; }

        /// <summary>
        /// Gets the last node of the linked list, null if empty
        /// </summary>
        IDoubleLinkedNode<T> Last { get; }

        /// <summary>
        /// Gets count of the all elements
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Inserts the element to the end of the list
        /// </summary>
        /// <param name="element">element to insert</param>
        void Insert(T element);

        /// <summary>
        /// Inserts the element to the specific position of the list
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">Thrown where index is less than 0 or more than Length</exception>
        /// <param name="element">element to insert</param>
        /// <param name="index">index where to insert</param>
        void InsertAt(T element, int index);

        /// <summary>
        /// Removes first entrance of the element in the list
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when list doesn't contains such element</exception>
        /// <param name="element">element to add</param>
        void Remove(T element);

        /// <summary>
        /// Removes element on the specific position
        /// </summary>
        /// <exception cref="System.IndexOutOfRangeException">Thrown where index is less than 0 or more than Length - 1</exception>
        /// <param name="index">index of the element</param>
        void RemoveAt(int index);

        /// <summary>
        /// Clears the list
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns first node of the list which contains such data
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when element doesn't exists</exception>
        /// <param name="searchElement">data of the node</param>
        /// <returns>node which contains this element</returns>
        IDoubleLinkedNode<T> Search(T searchElement);
    }
}