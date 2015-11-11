namespace SortingHomework.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void TestBinarySearchWithEmptyCollection()
        {
            var collection = new SortableCollection<int>();
            var result = collection.BinarySearch(101);

            Assert.IsFalse(result, "Element found in empty collection");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingRepeatingElementInCollection()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            var result = collection.BinarySearch(101);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithCollectionOfEqualElements()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 101, 101, 101 });
            var result = collection.BinarySearch(101);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingElementInFirstPositionEvenCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0 });
            var result = collection.BinarySearch(49);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingElementInFirstPositionOddCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0, 17 });
            var result = collection.BinarySearch(49);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingElementInMiddlePositionEvenCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0 });
            var result = collection.BinarySearch(33);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingElementInMiddlePositionOddCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0, 17 });
            var result = collection.BinarySearch(22);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingElementInLastPositionEvenCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0 });
            var result = collection.BinarySearch(0);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestBinarySearchWithExistingElementInLastPositionOddCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0, 17 });
            var result = collection.BinarySearch(17);

            Assert.IsTrue(result, "Element not found");
        }
    }
}