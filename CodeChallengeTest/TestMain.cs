using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using CodeChallenge.Interfaces;
using CodeChallenge;
using Swapi.Interfaces;
using Swapi.Program;
using Swapi.Models;

namespace CodeChallengeTest
{
    [TestClass]
    public class TestMain
    {
        protected readonly Container container;
         public TestMain()
        {
            container = new Container();

            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            container.Register<IWriter, Writer>();
            container.Register<IStopsCalculator, StopsCalculator>();
            container.Register<IStarship, StarShip>();
            container.Register<IStarshipMeasures, StarShip>();

            container.Verify();
        }
    }
}
