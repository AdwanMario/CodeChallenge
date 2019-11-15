#region Using
using CodeChallenge.Interfaces;
using Swapi.Interfaces;
using Swapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace CodeChallenge
{
    public class Executer
    {
        #region Members
        private readonly IStarshipService starshipservice;
        private readonly IWriter writer;
        private readonly IStopsCalculator calculator;
        private List<StarShip> starships;
        #endregion

        #region Constructors
        /// <summary>
        /// Invoked when an instance is created
        /// This class instace will be created using the package <see href="https://github.com/simpleinjector/">SimpleInjector</see>
        /// Parameters will be injected automatically through simple injector DI
        /// </summary>
        /// <param name="_starshipservice">Reperesents the service to read starships from the api</param>
        /// <param name="_writer">Represents the class to write into the console</param>
        /// <param name="_calculator">Represents the class to calculate measures from the <seealso cref="StarShip"/> Model</param>
        public Executer(IStarshipService _starshipservice, IWriter _writer, IStopsCalculator _calculator)
        {
            this.starshipservice = _starshipservice;
            this.writer = _writer;
            this.calculator = _calculator;
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method is used to initialize this class and get the Starships data from the <see href="https://swapi.co/">API</see>
        /// </summary>
        public async Task Intialize()
        {
            writer.Info("Getting starships");
            starships = await starshipservice.GetStarships();
        }

        /// <summary>
        /// Searches the list of starships and calculate the number of stops needed to cover a certain distance
        /// Categorizes the starships with valid and invalid data
        /// Writes each category seperately, and the amount of stops needed for each starship with valid data
        /// </summary>
        /// <param name="distance">The distance that needs to be covered by the starships</param>
        public void Execute(long distance)
        {
            if(starships == null) { throw new ArgumentNullException(nameof(starships)); }

            foreach (StarShip starship in starships.Where(x=>x.MGLTConverted != 0).ToList())
            {
                {
                    calculator.stops(starship, distance);
                    writer.data(starship.name + ": " + starship.stops);
                }
            }

            if(starships.Where(x=> x.MGLTConverted == 0).Count() != 0)
            {
                writer.Info("Starships with invalid data:");
                starships.Where(x => x.MGLTConverted == 0).ToList().ForEach((x) => writer.data(x.name));
            }

            writer.Info("Stops has been calculated successfully");
            writer.Info("Enter new distance or \"Exit\" to quit");
        }
        #endregion
    }
}
