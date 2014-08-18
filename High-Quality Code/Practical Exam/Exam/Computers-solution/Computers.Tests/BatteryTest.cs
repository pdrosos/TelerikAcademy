namespace Computers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computers.Components;

    /// <summary>
    /// Summary description for JustMockTest
    /// </summary>
    [TestClass]
    public class BatteryTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ChargeWithMoreThanFiftyShouldReturnOneHundred()
        {
            Battery battery = new Battery();
            battery.Charge(51);

            Assert.AreEqual(battery.Percentage, 100);
        }

        [TestMethod]
        public void ChargeWithTenShouldReturnSixty()
        {
            Battery battery = new Battery();
            battery.Charge(10);

            Assert.AreEqual(battery.Percentage, 60);
        }

        [TestMethod]
        public void DischargeWithMoreThanFiftyShouldReturnZero()
        {
            Battery battery = new Battery();
            battery.Charge(-51);

            Assert.AreEqual(battery.Percentage, 0);
        }

        [TestMethod]
        public void DischargeWithTenShouldReturnFourty()
        {
            Battery battery = new Battery();
            battery.Charge(-10);

            Assert.AreEqual(battery.Percentage, 40);
        }
    }
}
