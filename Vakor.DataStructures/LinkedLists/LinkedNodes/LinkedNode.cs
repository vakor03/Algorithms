namespace Vakor.DataStructures.LinkedLists.LinkedNodes
{
    public class LinkedNode<T> : ILinkedNode<T>
    {
        public LinkedNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        
        public ILinkedNode<T> NextElement { get; set; }
    }
}