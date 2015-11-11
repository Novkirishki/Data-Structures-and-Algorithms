namespace SortingHomework.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void TestMergeSortingWithEmptyCollection()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items.Count, "Collection is not empty after sorting");
        }

        [TestMethod]
        public void TestMergeSortingWithNotSortedCollectionWithEvenCount()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestMergeSortingWithNotSortedCollectionWithOddCount()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101, 44 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(44, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[6], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestMergeSortingWithSortedDescendingCollectionWithEvenCount()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestMergeSortingWithSortedDescendingCollectionWithOddCount()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 44, 33, 22, 11, 0 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(44, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[6], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestMergeSortingWithSortedCollectionWithEvenCount()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestMergeSortingWithSortedCollectionWithOddCount()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 44, 101, 101 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(0, collection.Items[0], "Collection is not sorted right.");
            Assert.AreEqual(11, collection.Items[1], "Collection is not sorted right.");
            Assert.AreEqual(22, collection.Items[2], "Collection is not sorted right.");
            Assert.AreEqual(33, collection.Items[3], "Collection is not sorted right.");
            Assert.AreEqual(44, collection.Items[4], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[5], "Collection is not sorted right.");
            Assert.AreEqual(101, collection.Items[6], "Collection is not sorted right.");
        }

        [TestMethod]
        public void TestMergeSortingWithLargeCollection()
        {
            var numbers = new int[10001];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 10000 - i;
            }

            var collection = new SortableCollection<int>(numbers);
            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count; i++)
            {
                Assert.AreEqual(i, collection.Items[i], "Collection is not sorted right");
            }
        }
    }
}
