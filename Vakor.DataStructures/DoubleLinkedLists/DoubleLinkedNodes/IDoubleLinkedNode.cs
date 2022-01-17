namespace Vakor.DataStructures.DoubleLinkedLists.DoubleLinkedNodes
{
    public interface IDoubleLinkedNode<T>
    {
        T Data { get; set; }
        
        IDoubleLinkedNode<T> NextElement { get; set; }
        IDoubleLinkedNode<T> PrevElement { get; set; }
    }
}