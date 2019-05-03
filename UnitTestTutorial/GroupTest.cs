using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialsPoint.Groups;
using TutorialsPoint.Groups.Permutations;

namespace UnitTestTutorial
{
    [TestClass]
    public class GroupTest
    {
        [TestMethod]
        public void TestGroupAxioms()
        {
            var S4 = new SymmetricGroup(4);

            Assert.IsTrue(S4.IsClosedUnderOperation());
            Assert.IsNotNull(S4.IdentityElement());
            Assert.IsTrue(S4.EachElementHasInverse());
            Assert.IsTrue(S4.IsOperationAssociative());
            Assert.IsTrue(S4.IsValidGroup());
        }
    }
}
