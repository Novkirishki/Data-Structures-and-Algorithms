namespace SortingHomework.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void TestLinearSearchWithEmptyCollection()
        {
            var collection = new SortableCollection<int>();
            var result = collection.LinearSearch(101);

            Assert.IsFalse(result, "Element found in empty collection");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingRepeatingElementInCollection()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            var result = collection.LinearSearch(101);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithCollectionOfEqualElements()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 101, 101, 101 });
            var result = collection.LinearSearch(101);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingElementInFirstPositionEvenCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0 });
            var result = collection.LinearSearch(49);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingElementInFirstPositionOddCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0, 17 });
            var result = collection.LinearSearch(49);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingElementInMiddlePositionEvenCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0 });
            var result = collection.LinearSearch(33);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingElementInMiddlePositionOddCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0, 17 });
            var result = collection.LinearSearch(22);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingElementInLastPositionEvenCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0 });
            var result = collection.LinearSearch(0);

            Assert.IsTrue(result, "Element not found");
        }

        [TestMethod]
        public void TestLinearSearchWithExistingElementInLastPositionOddCountOfElements()
        {
            var collection = new SortableCollection<int>(new[] { 49, 101, 33, 22, 11, 0, 17 });
            var result = collection.LinearSearch(17);

            Assert.IsTrue(result, "Element not found");
        }
    }
}