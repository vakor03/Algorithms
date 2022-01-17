namespace Vakor.DataStructures.DoubleLinkedLists.DoubleLinkedNodes
{
    public class DoubleLinkedNode<T> : IDoubleLinkedNode<T>
    {
        public DoubleLinkedNode(T data)
        {
            Data = data;
        }

                public T Data { get; set; }
        public IDoubleLinkedNode<T> NextElement { get; set; }
        public IDoubleLinkedNode<T> PrevElement { get; set; }
    }
}