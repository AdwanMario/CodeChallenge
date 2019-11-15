using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.Interfaces;
using Swapi.Models;

namespace CodeChallengeTest
{
    [TestClass]
    public class TestConsumptionDetails: TestMain
    {
       
        private StarShip starship;
        private IStarship starshipbase;
        private IStarshipMeasures starshipmeasures;

        [TestInitialize]
        public void Init()
        {
            starship = container.GetInstance<StarShip>();
            starshipbase = starship;
            starshipmeasures = starship;
        }

        [TestMethod]
        public void testTryConvert()
        {
            Assert.AreSame(starshipbase, starshipmeasures);
        }

        [TestMethod]
        public void testMgltUnknown()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.MGLT = "Unknown";
            

            Assert.AreEqual(starshipmeasures.MGLTConverted,0);
        }

        [TestMethod]
        public void testMgltConversion()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.MGLT = "100";
            Assert.AreEqual(starshipmeasures.MGLTConverted, 100);
        }

        [TestMethod]
        public void testConsumptionDetailInvalidConsumableForUom()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom,  Swapi.Program.Enums.UOM.Invalid);
        }
        [TestMethod]
        public void testConsumptionDetailInvalidConsumableForTime()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "";
            Assert.AreEqual(starshipmeasures.consumptiondetail.Time, -1);
        }

        [TestMethod]
        public void testConsumptionDetailWrongUom()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 dd";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Invalid);
        }

        [TestMethod]
        public void testConsumptionDetailUOMDays()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "2 Days";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Day);
        }
        [TestMethod]
        public void testConsumptionDetailUOMDay()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Day";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Day);
        }

        [TestMethod]
        public void testConsumptionDetailUOMHour()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Hour";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Hour);
        }

        [TestMethod]
        public void testConsumptionDetailUOMHours()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Hours";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Hour);
        }
        [TestMethod]
        public void testConsumptionDetailUOMMonth()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Month";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Month);
        }
        [TestMethod]
        public void testConsumptionDetailUOMMonths()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Months";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Month);
        }
        [TestMethod]
        public void testConsumptionDetailUOMWeek()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Week";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Week);
        }

        [TestMethod]
        public void testConsumptionDetailUOMWeeks()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 Weeks";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Week);
        }
        [TestMethod]
        public void testConsumptionDetailUOMYears()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 years";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Year);
        }
        [TestMethod]
        public void testConsumptionDetailUOMYear()
        {
            IStarship starshipbase = starship;
            IStarshipMeasures starshipmeasures = starship;

            starshipbase.consumables = "1 year";
            Assert.AreEqual(starshipmeasures.consumptiondetail.uom, Swapi.Program.Enums.UOM.Year);
        }
    }
}
