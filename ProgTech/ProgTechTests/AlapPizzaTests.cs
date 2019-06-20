using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTech.Tests
{
    [TestClass()]
    public class AlapPizzaTests
    {
        [TestMethod()]
        public void GetInfoTest()
        {
            AlapPizza pizza = new AlapPizza();
            Assert.AreEqual("pizza", pizza.GetInfo());
        }
    }
}