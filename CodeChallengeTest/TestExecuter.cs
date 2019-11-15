using CodeChallenge.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Swapi.Models;
using CodeChallenge;

namespace CodeChallengeTest
{


    [TestClass]
    public class TestExecuter: TestMain
    {
        
        private IStarshipService starshipservice;
        private IWriter writer;
        private IStopsCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            starshipservice = Substitute.For<IStarshipService>();
            writer = Substitute.For<IWriter>();
            calculator = Substitute.For<IStopsCalculator>();

        }

        [TestMethod]
        public async Task TestWriterStartingInfo()
        {
            starshipservice.GetStarships().Returns(new List<StarShip>
            {
                new StarShip()
            });

            Executer exc = new Executer(starshipservice, writer, calculator);
            await exc.Intialize();
             

            writer.Received().Info("Getting starships"); 
        }

        [TestMethod]
        public async Task TestWriterInvalidData()
        {
            starshipservice.GetStarships().Returns(new List<StarShip>
            {
                new StarShip { name = "Executor" }
            });

            Executer exc = new Executer(starshipservice, writer, calculator);
            await exc.Intialize();

            exc.Execute(1000000);

            writer.Received().Info("Starships with invalid data:");
            writer.Received().data("Executor");
            writer.Received().Info("Stops has been calculated successfully");
            writer.Received().Info("Enter new distance or \"Exit\" to quit");
        }

        [TestMethod]
        public async Task TestWriterInvalidMglt()
        {
            starshipservice.GetStarships().Returns(new List<StarShip>
            {
                new StarShip { name = "Executor", MGLTConverted = 0 }
            });

            Executer exc = new Executer(starshipservice, writer, calculator);
            await exc.Intialize();

            exc.Execute(1000000);

            writer.Received().Info("Starships with invalid data:");
            writer.Received().data("Executor");
            writer.Received().Info("Stops has been calculated successfully");
            writer.Received().Info("Enter new distance or \"Exit\" to quit");
        }

        [TestMethod]
        public async Task TestWriterInvalidConsumptionDetail()
        {
            starshipservice.GetStarships().Returns(new List<StarShip>
            {
                new StarShip { name = "Executor", consumables = "" }
            });

            Executer exc = new Executer(starshipservice, writer, calculator);
            await exc.Intialize();

            exc.Execute(1000000);

            writer.Received().Info("Starships with invalid data:");
            writer.Received().data("Executor");
            writer.Received().Info("Stops has been calculated successfully");
            writer.Received().Info("Enter new distance or \"Exit\" to quit");
        }

        [TestMethod]
        public async Task TestWriterCorrectData()
        {
            starshipservice.GetStarships().Returns(new List<StarShip>
            {
                new StarShip { name = "Executor", consumables = "6 years", MGLT="40" }
            });

            calculator = container.GetInstance<IStopsCalculator>();
            Executer exc = new Executer(starshipservice, writer, calculator);
            await exc.Intialize();
            var distance = 10000000;
            
            exc.Execute(distance);

            writer.Received().Info("Getting starships");
            writer.Received().data("Executor: 4");
            writer.Received().Info("Stops has been calculated successfully");
            writer.Received().Info("Enter new distance or \"Exit\" to quit");
        }

    }
}
