using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialsPoint.DataStructures;

namespace UnitTestTutorial
{
    [TestClass]
    public class HashSetByPropertyTest
    {
        [TestMethod]
        public void TestHashSetByValueTypeProperty()
        {
            var rand = new Random();
            var hashSet = new HashSetByProperty<SinglePropertyClass, int>(x => x.ValueTypeProperty);
            for(var i =  0; i < 100; i++)
            {
                hashSet.Add(new SinglePropertyClass() { ValueTypeProperty = rand.Next(0,5) });
            }
        }

        private class SinglePropertyClass
        {
            public int ValueTypeProperty { get; set; }
        }
    }
}
