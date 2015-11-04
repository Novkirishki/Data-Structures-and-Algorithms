namespace HashSet.Tests
{
    using _5.HashSet;
    using NUnit.Framework;

    [TestFixture]
    public class HashSetTests
    {
        [Test]
        public void InitialCountShouldBeZero()
        {
            var hashtable = new HashSet<string>();

            Assert.AreEqual(0, hashtable.Count);
        }

        [Test]
        public void CountShouldBeCorrectWhenThereAreAddedElements()
        {
            var hashtable = new HashSet<string>();

            hashtable.Add("aaa");
            hashtable.Add("bbb");
            hashtable.Add("ccc");

            Assert.AreEqual(3, hashtable.Count);
        }

        [Test]
        public void CountShouldBeCorrectAfterRemovingElements()
        {
            var hashtable = new HashSet<string>();

            hashtable.Add("aaa");
            hashtable.Add("bbb");
            hashtable.Add("ccc");
            hashtable.Remove("aaa");

            Assert.AreEqual(2, hashtable.Count);
        }

        [Test]
        public void FindShouldReturnTrueForAddedElement()
        {
            var hashtable = new HashSet<string>();

            hashtable.Add("aaa");

            Assert.IsTrue(hashtable.Find("aaa"));
        }

        [Test]
        public void FindShouldReturnFalseIfKeyIsNotAdded()
        {
            var hashtable = new HashSet<string>();

            Assert.IsFalse(hashtable.Find("aaa"));
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            var hashtable = new HashSet<int>();

            hashtable.Add(10);

            Assert.IsTrue(hashtable.Find(10));

            hashtable.Remove(10);

            Assert.IsFalse(hashtable.Find(10));
        }

        [Test]
        public void ClearShouldClearCount()
        {
            var hashtable = new HashSet<int>();

            hashtable.Add(10);

            Assert.AreEqual(1, hashtable.Count);

            hashtable.Clear();

            Assert.AreEqual(0, hashtable.Count);
        }

        [Test]
        public void ClearShouldRemoveElement()
        {
            var hashtable = new HashSet<int>();

            hashtable.Add(10);

            Assert.IsTrue(hashtable.Find(10));

            hashtable.Clear();

            Assert.IsFalse(hashtable.Find(10));
        }

        [Test]
        public void UnionWithShouldWorkProperly()
        {
            var hashset = new HashSet<int>();

            hashset.Add(1);

            var hashset2 = new HashSet<int>();

            hashset2.Add(2);

            var result = hashset.UnionWith(hashset2);

            Assert.IsTrue(result.Find(1));
            Assert.IsTrue(result.Find(2));
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void UnionWithShouldNotAddElementTwice()
        {
            var hashset = new HashSet<int>();

            hashset.Add(1);
            hashset.Add(2);

            var hashset2 = new HashSet<int>();

            hashset2.Add(2);

            var result = hashset.UnionWith(hashset2);

            Assert.IsTrue(result.Find(1));
            Assert.IsTrue(result.Find(2));
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void IntersectShouldWorkProperly()
        {
            var hashset = new HashSet<int>();

            hashset.Add(1);
            hashset.Add(2);

            var hashset2 = new HashSet<int>();

            hashset2.Add(2);

            var result = hashset.IntersectWith(hashset2);
            
            Assert.IsTrue(result.Find(2));
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void IntersectShouldReturnEmptySetWhenNoCommonElements()
        {
            var hashset = new HashSet<int>();

            hashset.Add(1);

            var hashset2 = new HashSet<int>();

            hashset2.Add(2);

            var result = hashset.IntersectWith(hashset2);
            
            Assert.AreEqual(0, result.Count);
        }
    }
}
