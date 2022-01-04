namespace AlgorithmsWebApp.Models
{
    public class LinkedList
    {
        private Node head;

        public void printAllNodes()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void AddFirst(Object data)
        {
            Node toAdd = new Node();

            toAdd.Data = data;
            toAdd.Next = head;

            head = toAdd;
        }

        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();

                head.Data = data;
                head.Next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.Data = data;

                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toAdd;
            }
        }
    }
}
