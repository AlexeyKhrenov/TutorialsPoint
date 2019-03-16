using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialsPoint.Algorithms;

namespace UnitTestTutorial
{
    [TestClass]
    public class SortingTest
    {
        private int[] testArray = new int[11] { 5, 6, 3, 3, 6, 2, 0, 1, 15, 24, 11 };
        private int[] resultArray = new int[11] { 0, 1, 2, 3, 3, 5, 6, 6, 11, 15, 24 };
        Sorting<int> sort = new Sorting<int>();

        [TestMethod]
        public void TestBubleSorting()
        {
            sort.BubbleSort(testArray);
            AssertSequenceEquals(testArray, resultArray);
        }

        [TestMethod]
        public void TestInsertionSort()
        {
            sort.InsertionSort(testArray);
            AssertSequenceEquals(testArray, resultArray);
        }

        [TestMethod]
        public void TestSelectionSort()
        {
            sort.SelectionSort(testArray);
            AssertSequenceEquals(testArray, resultArray);
        }

        private void AssertSequenceEquals<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            Assert.IsTrue(a.SequenceEqual(b));
        }
    }
}
