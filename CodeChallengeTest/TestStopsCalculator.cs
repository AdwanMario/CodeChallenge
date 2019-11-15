using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.Interfaces;
using SimpleInjector;
using CodeChallenge.Interfaces;
using CodeChallenge;
using Swapi.Program;

namespace CodeChallengeTest
{
    /// <summary>
    /// Summary description for TestStopsCalculator
    /// </summary>
    [TestClass]
    public class TestStopsCalculator: TestMain
    {

        private IStopsCalculator calculator;
        private IStarshipMeasures starship;
        public TestStopsCalculator()
        {

        }

        [TestInitialize]
        public void Init()
        {
            calculator = container.GetInstance<IStopsCalculator>();
            starship = container.GetInstance<IStarshipMeasures>();
        }
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
        public void testHours()
        {
            starship.consumptiondetail.uom = Enums.UOM.Hour;
            starship.consumptiondetail.Time = 10;
            var hours = calculator.hours(starship);
            var expected = 10;

            Assert.AreEqual(hours, expected);
        }
        [TestMethod]
        public void testdays()
        {
            starship.consumptiondetail.uom = Enums.UOM.Day;
            starship.consumptiondetail.Time = 10;
            var hours = calculator.hours(starship);
            var expected = 240;

            Assert.AreEqual(hours, expected);
        }
        [TestMethod]
        public void testweeks()
        {
            starship.consumptiondetail.uom = Enums.UOM.Week;
            starship.consumptiondetail.Time = 10;
            var hours = calculator.hours(starship);
            var expected = 1680;

            Assert.AreEqual(hours, expected);
        }
        [TestMethod]
        public void testMonth()
        {
            starship.consumptiondetail.uom = Enums.UOM.Month;
            starship.consumptiondetail.Time = 10;
            var hours = calculator.hours(starship);
            var expected = 7300;

            Assert.AreEqual(hours, expected);
        }
        [TestMethod]
        public void testYear()
        {
            starship.consumptiondetail.uom = Enums.UOM.Year;
            starship.consumptiondetail.Time = 10;
            var hours = calculator.hours(starship);
            var expected = 87600;

            Assert.AreEqual(hours, expected);
        }
        [TestMethod]
        public void testUnknown()
        {
            starship.consumptiondetail.uom = Enums.UOM.Invalid;
            starship.consumptiondetail.Time = 10;
            var hours = calculator.hours(starship);
            var expected = 0;

            Assert.AreEqual(hours, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_null()
        {
            starship.consumptiondetail = null;
            var hours = calculator.hours(starship);
        }

        [TestMethod]
        public void testStopsWrongUom()
        {
            starship.consumptiondetail.uom = Enums.UOM.Invalid;
            starship.consumptiondetail.Time = 1;
            calculator.stops(starship, 0);
            Assert.AreEqual(0, starship.stops);
        }
        [TestMethod]
        public void testStopsWrongTime()
        {
            starship.consumptiondetail.uom = Enums.UOM.Day;
            starship.consumptiondetail.Time = -1;
            calculator.stops(starship, 0);
            Assert.AreEqual(0, starship.stops);
        }
        [TestMethod]
        public void testStopsWrongMGLT()
        {
            starship.consumptiondetail.uom = Enums.UOM.Day;
            starship.consumptiondetail.Time = 1;
            starship.MGLTConverted = 0;
            calculator.stops(starship, 0);
            Assert.AreEqual(0, starship.stops);
        }

        [TestMethod]
        public void testStopsCalculation()
        {
            starship.consumptiondetail.uom = Enums.UOM.Year;
            starship.consumptiondetail.Time = 6;
            starship.MGLTConverted = 40;
            calculator.stops(starship, 10000000);
            Assert.AreEqual(4, starship.stops);
        }
    }
}
