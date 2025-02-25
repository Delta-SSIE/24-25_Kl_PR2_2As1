using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04_UnitTesting_01_Minimum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_UnitTesting_01_Minimum.Tests
{
    [TestClass()]
    public class ToolsTests
    {
        [TestMethod()]
        public void FindMinTest()
        {
            int[] nums = [1, 2, -4, 18];
            Assert.AreEqual(-4, Tools.FindMin(nums));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMinEmptySetTest()
        {
            int[] nums = [];
            Tools.FindMin(nums);
            //když dojde do cíle, je to špatně
            Assert.Fail();
        }

    }
}