namespace Vakor.DataStructures.Stacks
{
    //Principle Last input First Output
    public interface IStack<T>
    {
        /// <summary>
        /// Returns number of elements in stack
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Adds element to the top of the stack
        /// </summary>
        /// <param name="element">element to add</param>
        void Push(T element);

        /// <summary>
        /// Returns top element of the stack and removes it from stack
        /// </summary>
        /// <returns>top element of stack</returns>
        T Pop();
    }
}