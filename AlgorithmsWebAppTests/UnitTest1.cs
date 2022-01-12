using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsWebApp.Models;
using System.Collections.Generic;

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

        [TestMethod]
        public void CreateLinkedListConnectsNodes()
        {
            List<Node> nodes = new List<Node> { new Node("first", null), new Node("second", null), new Node("third", null) };

            Node head = AlgorithmsWebApp.Algorithms.CreateLinkedList(nodes);

            Assert.AreEqual(head.Data, "first");
            Assert.AreEqual(head.Next.Data, "second");
            Assert.AreEqual(head.Next.Next.Data, "third");
            Assert.AreEqual(head.Next.Next.Next, null);


        }

        [TestMethod]
        public void RemoveNodeFromLinkedListRemovesCorrectNode()
        { 
            AlgorithmsWebApp.Algorithms.RemoveNodeFromLinkedList(head, 1);
            Assert.AreEqual(head.Next.Data, "third value");
        }

        [TestMethod]
        public void DoublyLinkedListNodesLinkedProperly()
        {
            DoublyLinkedNode first = new DoublyLinkedNode("first");
            DoublyLinkedNode second = new DoublyLinkedNode("second");
            DoublyLinkedNode third = new DoublyLinkedNode("third");

            first.Next = second;
            second.Previous = first;
            second.Next = third;
            third.Previous = second;

            Assert.AreEqual(first.Next.Data, "second");
            Assert.AreEqual(third.Previous.Data, "second");
            Assert.AreEqual(first.Next.Next.Data, "third");
            Assert.AreEqual(second.Previous.Data, "first");
        }

        [TestMethod]
        public void DoublyLinkedListInsertionLinksNodes()
        {
            DoublyLinkedNode first = new DoublyLinkedNode("first");
            DoublyLinkedNode second = new DoublyLinkedNode("second");
            DoublyLinkedNode third = new DoublyLinkedNode("third");

            first.Next = second;
            second.Previous = first;
            second.Next = third;
            third.Previous = second;

            AlgorithmsWebApp.Algorithms.DoublyLinkedListInsertNode(1, new DoublyLinkedNode("new val"), first);

            Assert.AreEqual(first.Next.Data, "new val");
            Assert.AreEqual(second.Previous.Data, "new val");
            Assert.AreEqual(third.Previous.Previous.Data, "new val");

        }

        [TestMethod]
        public void DoublyLinkedListRemovalLinksNodes()
        {
            DoublyLinkedNode first = new DoublyLinkedNode("first");
            DoublyLinkedNode second = new DoublyLinkedNode("second");
            DoublyLinkedNode third = new DoublyLinkedNode("third");

            first.Next = second;
            second.Previous = first;
            second.Next = third;
            third.Previous = second;

            AlgorithmsWebApp.Algorithms.DoublyLinkedListRemoveNode(first, 1);

            Assert.AreEqual("third", first.Next.Data);
            Assert.AreEqual("first", third.Previous.Data);

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