// You have to install Nunit test adapter through VS extensions and updates
// (Tools -> Extenions and Updates)

namespace HashTable.Tests
{
    using NUnit.Framework;
    using _4.HashTable;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class HashTableTests
    {
        private static string[] sampleNames = new string[]
        {
            "gosho", "tosho", "ivan", "skumriq", "gencho", "pencho", "penka", "stamat", "pako",
            "djodjo", "strahil", "maria", "uruspiq", "ginka", "nikola", "djena", "plamena", "enrike"
        };

        [Test]
        public void InitialCountShouldBeZero()
        {
            var hashtable = new HashTable<string, int>();

            Assert.AreEqual(0, hashtable.Count);
        }

        [Test]
        public void CountShouldBeCorrectWhenThereAreAddedElements()
        {
            var hashtable = new HashTable<string, int>();

            hashtable.Add("aaa", 1);
            hashtable.Add("bbb", 1);
            hashtable.Add("ccc", 1);

            Assert.AreEqual(3, hashtable.Count);
        }

        [Test]
        public void CountShouldBeCorrectAfterRemovingElements()
        {
            var hashtable = new HashTable<string, int>();

            hashtable.Add("aaa", 1);
            hashtable.Add("bbb", 1);
            hashtable.Add("ccc", 1);
            hashtable.Remove("aaa");

            Assert.AreEqual(2, hashtable.Count);
        }

        [Test]
        public void IndexerShouldReturnTheElementAddedWithAdd()
        {
            var hashtable = new HashTable<string, int>();

            var key = "aaa";
            var value = 12;

            hashtable.Add(key, value);

            Assert.AreEqual(value, hashtable[key]);
        }

        [Test]
        public void FindShouldReturnTheElementAddedWithAdd()
        {
            var hashtable = new HashTable<string, int>();

            var key = "aaa";
            var value = 12;

            hashtable.Add(key, value);

            Assert.AreEqual(value, hashtable.Find(key));
        }

        [Test]
        public void CapacityShouldDoubleAtSeventyFivePercentLoad()
        {
            var hashtable = new HashTable<string, int>();
            var startingCapacity = hashtable.Capacity;

            foreach (var name in sampleNames.Take(13))
            {
                hashtable.Add(name, 17);
            }

            Assert.AreEqual(startingCapacity * 2, hashtable.Capacity);
        }

        [Test]
        public void CapacityShouldIncreasePersistently()
        {
            var hashtable = new HashTable<string, int>();
            var lastCapacity = hashtable.Capacity;
            var counter = 16;
            var next = 0;

            while (hashtable.Count < 1024)
            {
                for (int i = 0; i < 1 + (counter * 3) / 4; i++)
                {
                    hashtable.Add((next++).ToString(), 13);
                }

                lastCapacity = hashtable.Capacity;
                counter *= 2;

                Assert.AreEqual(counter, lastCapacity);
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddShouldThrowExceptionWhenTheSameKeyIsAlreadyPresent()
        {
            var hashtable = new HashTable<string, int>();

            hashtable.Add("gosho", 12);
            hashtable.Add("gosho", 2);
        }

        [Test]
        public void KeysShouldBeStoredWhenPairIsAdded()
        {
            var hashtable = new HashTable<string, int>();

            var key = "Ivan";

            hashtable.Add(key, 12);

            Assert.IsTrue(hashtable.Keys.Contains(key));
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void FindShouldThrowIfKeyIsNotAdded()
        {
            var hashtable = new HashTable<int, string>();
            var a = hashtable[12];
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            hashtable.Remove(10);

            Assert.AreEqual(0, hashtable.Count);
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveShouldWorkProperly2()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            hashtable.Remove(10);

            var a = hashtable[10];
        }

        [Test]
        public void RemoveShouldRemoveFromKeys()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.IsTrue(hashtable.Keys.Contains(10));

            hashtable.Remove(10);

            Assert.IsFalse(hashtable.Keys.Contains(10));
        }

        [Test]
        public void ClearShouldClearCount()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(1, hashtable.Count);

            hashtable.Clear();

            Assert.AreEqual(0, hashtable.Count);
        }

        [Test]
        public void ClearShouldClearKeys()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.IsTrue(hashtable.Keys.Contains(10));

            hashtable.Clear();

            Assert.IsFalse(hashtable.Keys.Contains(10));
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ClearShouldRemovePair()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            hashtable.Clear();

            var a = hashtable[10];
        }

        [Test]
        public void IndexerShouldAddPair()
        {
            var hashtable = new HashTable<string, int>();

            hashtable["aaa"] = 12;

            Assert.AreEqual(12, hashtable["aaa"]);
        }

        [Test]
        public void IndexerShouldChangeValueOfAddedPair()
        {
            var hashtable = new HashTable<string, int>();

            hashtable["aaa"] = 12;
            hashtable["aaa"] = 13;

            Assert.AreEqual(13, hashtable["aaa"]);
        }
    }
}
