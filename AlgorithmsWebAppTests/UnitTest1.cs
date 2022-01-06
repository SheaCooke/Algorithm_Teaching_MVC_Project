using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsWebApp.Models;

namespace AlgorithmsWebAppTests
{
    [TestClass]
    public class UnitTest1
    {
        private int[] _sortedIntArray = new int[] { 1, 2, 3, 4, 5 };

        private int[] _unSortedIntArray = new int[] { 1, 5, 3, 2, 4 };

        private int[] _sortedDoubleArray = new int[] { 1, 2, 3, 4, 5 };

        private int[] _unSortedDoubleArray = new int[] { 1, 5, 3, 2, 4 };

        Node head;
        Node second;
        Node third;


        [TestInitialize]
         public void initialize() //initialize and cleanup methods must be public 
         {
            head = new Node("first value");
            second = new Node("second value");
            third = new Node("third value");

            head.Next = second;
            second.Next = third;
        }




        [TestMethod]
        public void BinarySearchReturnsCorrectIndex()
        {
            int BinarySearchReturnedIndex = AlgorithmsWebApp.Algorithms.BinarySearch(_sortedIntArray, 2);

            Assert.AreEqual(1, BinarySearchReturnedIndex);
        }

        [TestMethod]
        public void BinarySearchReturnsNegTwoIfUnsortedCollection()
        {
            Assert.AreEqual(-2, AlgorithmsWebApp.Algorithms.BinarySearch(_unSortedIntArray, 2));
        }

        [TestMethod]
        public void IsArraySortedAscendingReturnsTrueForSorted()
        {
            Assert.AreEqual(true, AlgorithmsWebApp.Algorithms.IsArraySortedAscending(_sortedIntArray));
        }

        [TestMethod]
        public void IsArraySortedAscendingReturnsFalseForUnsorted()
        {
            Assert.AreEqual(false, AlgorithmsWebApp.Algorithms.IsArraySortedAscending(_unSortedIntArray));
        }


        [TestMethod]
        public void IsArraySortedAscendingReturnsTrueForSortedDouble()
        {
            Assert.AreEqual(true, AlgorithmsWebApp.Algorithms.IsArraySortedAscending(_sortedDoubleArray));
        }

        [TestMethod]
        public void IsArraySortedAscendingReturnsFalseForUnsortedDouble()
        {
            Assert.AreEqual(false, AlgorithmsWebApp.Algorithms.IsArraySortedAscending(_unSortedDoubleArray));
        }


        [TestMethod]
        public void LinkedListAddsNodes()
        {

            Assert.AreEqual("second value", head.Next.Data);
            Assert.AreEqual("third value", head.Next.Next.Data);

        }

        [TestMethod]
        public void LinkedListInsertion()
        {
         
            Node ToBeInserted = new Node("inserted value");
            AlgorithmsWebApp.Algorithms.LinkedListInsertion(1, ToBeInserted, head);

            Assert.AreEqual("inserted value", head.Next.Data);

            Node ToBeInserted2 = new Node("Second inserted value");
            AlgorithmsWebApp.Algorithms.LinkedListInsertion(3, ToBeInserted2, head);

            Assert.AreEqual("Second inserted value", head.Next.Next.Next.Data);


        }


        [TestCleanup]
        public void CleanUp()
        {
            head = null;
            second = null;
            third = null;
        }
    }
}