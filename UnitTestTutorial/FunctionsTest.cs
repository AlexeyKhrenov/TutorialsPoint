using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialsPoint.Functions;

namespace UnitTestTutorial
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void FactorialTest()
        {
            ulong answer = 2432902008176640000;
            Assert.AreEqual(Recursive.Factorial(20), answer);
            Assert.AreEqual(Iterative.Factorial(20), answer);
        }
    }
}
