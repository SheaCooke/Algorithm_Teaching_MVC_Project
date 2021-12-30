namespace AlgorithmsWebApp
{
    public class Algorithms
    {
        
        //ParseCollectionToArray, turn comma separated values into an array
        public static int[] ParseCollectionToArray(string collection)
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

        public static int BinarySearch(int[] collection, int target)//returns the index of the specified element
        {
            int index = 0;

            foreach (var i in collection)
            {
                index += i;
            }

            return index;
        }



    }
}
