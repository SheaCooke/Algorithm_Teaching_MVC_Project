using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsWebAppTests
{
    [TestClass]
    public class UnitTest1
    {
        private int[] _collection = new int[] { 1, 2, 3, 4, 5 };

        /* [TestInitialize]
         private void initialize()
         {
             collection = new int[] { 1, 2, 3, 4, 5 };
         }*/




        [TestMethod]
        public void TestMethod1()
        {
            int BinarySearchReturnedIndex = AlgorithmsWebApp.Algorithms.BinarySearch(_collection, 2);

            Assert.AreEqual(15, BinarySearchReturnedIndex);
        }


        /*[TestCleanup]
        private void CleanUp()
        {
            collection = null;
        }*/
    }
}