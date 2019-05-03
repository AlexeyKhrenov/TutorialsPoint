using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialsPoint.Permutations;

namespace UnitTestTutorial
{
    [TestClass]
    public class PermutationTest
    {
        [TestMethod]
        public void TestIsValid()
        {
            var wrongPermutation = new int[4] { 0, 2, 3, 3 };
            var permutation = new Permutation(wrongPermutation);
            Assert.IsFalse(permutation.IsValid());

            wrongPermutation = new int[4] { 0, 2, 2, 3 };
            permutation = new Permutation(wrongPermutation);
            Assert.IsFalse(permutation.IsValid());

            wrongPermutation = new int[4] { 0, 2, 3, 4 };
            permutation = new Permutation(wrongPermutation);
            Assert.IsFalse(permutation.IsValid());

            var rightPermutation = new int[4] { 2, 3, 1, 0 };
            permutation = new Permutation(rightPermutation);
            Assert.IsTrue(permutation.IsValid());
        }

        [TestMethod]
        public void TestAdding()
        {
            var perm1 = new Permutation(new int[4] { 3, 0, 1, 2 });
            var perm2 = new Permutation(new int[4] { 2, 0, 3, 1 });
            var perm3 = new Permutation(new int[4] { 1, 3, 2, 0 });

            Assert.IsTrue(perm1 + perm2 == perm3);
        }
    }
}
