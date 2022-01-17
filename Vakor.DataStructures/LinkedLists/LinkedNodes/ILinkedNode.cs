namespace Vakor.DataStructures.LinkedLists.LinkedNodes
{
    public interface ILinkedNode<T>
    {
        T Data { get; set; }
        ILinkedNode<T> NextElement { get; set; }
    }
}