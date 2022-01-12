using AlgorithmsWebApp.Models;

namespace AlgorithmsWebApp
{
    public class Algorithms
    {
        
        //ParseCollectionToArray, turn comma separated values into an array
        public static int[] ParseToIntArray(string collection)
        {
            collection = collection.Trim();
            List<int> result = new List<int>();

            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] != ',')
                {
                    try
                    {
                        result.Add(Int32.Parse(collection[i].ToString()));
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Error "+e);
                    }
                }

            }

            return result.ToArray();
        }


        public static bool IsArraySortedAscending<T>(T[] collection)
        {

            T previous = collection[0];

            if (typeof(T) == typeof(int[]))
            {
                for (int i = 1; i < collection.Length; i++)
                {
                    if (Int32.Parse(previous.ToString()) > Int32.Parse(collection[i].ToString()))
                    {
                        return false;
                    }

                    previous = collection[i];
                }

                return true;
            }

            else 
            {
                for (int i = 1; i < collection.Length; i++)
                {
                    if (Double.Parse(previous.ToString()) > Double.Parse(collection[i].ToString()))
                    {
                        return false;
                    }

                    previous = collection[i];
                }

                return true;
            }

           
        }



        public static int BinarySearch(int[] collection, int target)//returns the index of the specified element, or -1
        {
            //check if array is sorted before preceeding 
            if (!IsArraySortedAscending(collection))
            {
                Console.WriteLine("Collection must be sorted");
                return -2;
            }

            int left = 0;
            int right = collection.Length - 1;
            int mid;

            while (left <= right)
            {
                mid = right - (right - left) / 2;

                if (collection[mid] > target)
                {
                    right = mid - 1;
                }
                else if (collection[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
               
            }

            return -1;
        }


        public static void LinkedListInsertion(int insertionPosition, Node node, Node head) //1 = insert right after head
        {
            Node dummy = new Node(null, head);

            Node left = dummy; //Because these objects (nodes) are reference types, they point or refer to a place in memory, so we can interact with the nodes (locations in memory) by creating more reference types
            Node right = head;

            while(right.Next != null && insertionPosition > 0)
            {
                right = right.Next;
                left = left.Next;
                insertionPosition--;
            }

            left.Next = node;

            node.Next = right;

        }

        public static void RemoveNodeFromLinkedList(Node head, int nodeToRemove)
        {
            if (head.Next == null)
            {
                return;
            }

            Node dummy = new Node(null, head);

            Node left = dummy; //reference to the same object in memory
            Node right = head;

            while (right.Next != null && nodeToRemove > 0)
            {
                nodeToRemove--;
                left = left.Next;
                right = right.Next;
            }
            right = right.Next;

            left.Next = right;

        }


        public static Node CreateLinkedList(List<Node> listOfNodes)
        {
            if (listOfNodes.Count <= 1)
            {
                return listOfNodes[0];
            }

            int right = 1;

            for (int left = 0; left < listOfNodes.Count - 1; left++)
            {
                listOfNodes[left].Next = listOfNodes[right];
                right++;
            }

            return listOfNodes[0];
        }


        public static void DoublyLinkedListInsertNode(int insertionPosition, DoublyLinkedNode node, DoublyLinkedNode head) //0 is before the head, 1 is immediately after
        {
            DoublyLinkedNode dummy = new DoublyLinkedNode(next:head);
            DoublyLinkedNode left = dummy;
            DoublyLinkedNode right = head;

            while (right.Next != null & insertionPosition > 0)
            {
                left = left.Next;
                right = right.Next;
                insertionPosition--;
            }

            left.Next = node;
            right.Previous = node;

            node.Next = right;
            node.Previous = left;

            dummy = null;
        }

        public static void DoublyLinkedListRemoveNode(DoublyLinkedNode head, int position) //position 0 = head
        {
            DoublyLinkedNode dummy = new DoublyLinkedNode(next: head);
            DoublyLinkedNode left = dummy;
            DoublyLinkedNode right = head;

            while (right.Next != null & position > 0)
            {
                left = left.Next;
                right = right.Next;
                position--;
            }

            right = right.Next;

            right.Previous = left;
            left.Next = right;

            dummy = null;


        }



    }
}
