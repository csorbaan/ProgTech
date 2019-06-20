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
    public class AdottPizzaTests
    {
        [TestMethod()]
        public void TipusChangeTest()
        {
            AdottPizza pizza = new AdottPizza();
            pizza.TipusChange(new AlapPizza(), "magyar");
            Assert.AreEqual("magyar", pizza.lang);
        }
    }
}