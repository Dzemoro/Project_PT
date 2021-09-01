using AppGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests {
    [TestClass]
    public class CountingTests {
        [TestMethod]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(20, 0.491, 5, 0.35, 16, 60.09, 3, 0.491, 5, 0.35, 0, -26.7)]
        [DataRow(20, 0.491, 5, 0.35, 16, 88.05, 3, 0.491, 5, 0.35, 10.1, -64.76)]
        public void CountingTest(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l) {
            double result = CountClass.CountTest(a, b, c, d, e, f, g, h, i, j, k);
            Assert.AreEqual(result, l);
        }
    }
}
