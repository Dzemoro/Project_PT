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
        public void CountingTest(double powerT, double wireT, double lenghtT, double connectorT, double gainT, double fsl, double gainR, double wireR, double lengthR, double connectorR, double obstacles, double result) {
            double testResult = CountClass.CountTest(powerT, wireT, lenghtT, connectorT, gainT, fsl, gainR, wireR, lengthR, connectorR, obstacles);
            Assert.AreEqual(testResult, result);
        }
    }
}
