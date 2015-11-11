namespace SortingHomework.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void TestQuickSortingWithEmptyCollection()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items.Count, "Collection is not empty after sorting");
        }

        [TestMethod]
        public void TestQuickSortingWithNotSortedCollectionWithEvenCount()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestQuickSortingWithNotSortedCollectionWithOddCount()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101, 44 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(44, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[6], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestQuickSortingWithSortedDescendingCollectionWithEvenCount()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestQuickSortingWithSortedDescendingCollectionWithOddCount()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 44, 33, 22, 11, 0 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(44, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[6], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestQuickSortingWithSortedCollectionWithEvenCount()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestQuickSortingWithSortedCollectionWithOddCount()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 44, 101, 101 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(44, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[6], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestQuickSortingWithLargeCollection()
        {
            var numbers = new int[10001];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 10000 - i;
            }

            var collection = new SortableCollection<int>(numbers);
            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count; i++)
            {
                Assert.AreEqual(i, collection.Items[i], "Collection is not sorted right");
            }
        }
    }
}
