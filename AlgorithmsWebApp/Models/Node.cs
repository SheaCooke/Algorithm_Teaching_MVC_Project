namespace AlgorithmsWebApp.Models
{
    public class Node
    {
        public object? Data;
        public Node? Next;

        public Node(object data = null, Node next = null)
        {
            Data = data;
            Next = next;
        }

        
    }
}
