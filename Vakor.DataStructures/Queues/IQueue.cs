namespace Vakor.DataStructures.Queues
{
    /// <summary>
    /// Queue structure: FIFO
    /// </summary>
    /// <typeparam name="T">any datatype</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Gets the count of the elements in queue
        /// </summary>
        int Length { get; }
        
        /// <summary>
        /// Adds element to the end of the queue
        /// </summary>
        /// <param name="element">element to add</param>
        void Enqueue(T element);

        /// <summary>
        /// Returns the first element of the queue
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown when queue is empty</exception>
        /// <returns>first element</returns>
        T Dequeue();

        /// <summary>
        /// Clears the queue
        /// </summary>
        void Clear();
    }
}