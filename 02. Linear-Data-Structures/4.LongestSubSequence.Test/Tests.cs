namespace _4.LongestSubSequence.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LongestSubsequenceOfEqualNumbers;
    using System.Collections.Generic;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CheckIfReturnsEmptyListWhenGivenEmptyList()
        {
            var sequence = Startup.FindMaxSubSequence(new List<int>());

            Assert.AreEqual(0, sequence.Count, "The method does not return an empty list when given empty list");
        }

        [TestMethod]
        public void CheckIfFindsFirstSubsequenceWhenThereAreTwoWithSameLength()
        {
            var sequence = Startup.FindMaxSubSequence(new List<int>() { 7, 1, 1, 1, 2, 2, 2, 3, 4, 5});

            Assert.AreEqual(3, sequence.Count, "The sub sequence count is not valid");
            Assert.AreEqual(1, sequence[0], "The sub sequence is not right");
        }

        [TestMethod]
        public void CheckIfFindsSubsequence()
        {
            var sequence = Startup.FindMaxSubSequence(new List<int>() { 7, 1, 1, 1, 2, 2, 2, 2, 3, 4, 5 });

            Assert.AreEqual(4, sequence.Count, "The sub sequence count is not valid");
            Assert.AreEqual(2, sequence[0], "The sub sequence is not right");
        }

        [TestMethod]
        public void CheckIfFindsSubsequenceWhenGivenOnlyOneNumber()
        {
            var sequence = Startup.FindMaxSubSequence(new List<int>() { 7 });

            Assert.AreEqual(1, sequence.Count, "The sub sequence count is not valid");
            Assert.AreEqual(7, sequence[0], "The sub sequence is not right");
        }
    }
}
