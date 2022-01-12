namespace AlgorithmsWebApp.Models
{
    public class DoublyLinkedNode
    {
        public object Data;

        public DoublyLinkedNode Next;

        public DoublyLinkedNode Previous;

        public DoublyLinkedNode(object data = null, DoublyLinkedNode next = null, DoublyLinkedNode previous = null)
        {
            this.Data = data;
            this.Next = next;
            this.Previous = previous;
        }
    }
}
