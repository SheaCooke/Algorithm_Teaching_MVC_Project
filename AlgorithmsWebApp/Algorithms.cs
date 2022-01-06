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

    }
}
