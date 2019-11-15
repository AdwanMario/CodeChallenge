using Swapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Interfaces
{
    /// <summary>
    /// Represents the service to get all starships from the <see href="https://swapi.co/">API</see>
    /// </summary>
    public interface IStarshipService
    {
        /// <summary>
        /// Reads the data from the Api and deserialize them into a List
        /// Also note that the Api returns the starships into seperate pages, supplying the next url for next page, when the next url is null means all data was downloaded
        /// </summary>
        /// <returns></returns>
        Task<List<StarShip>> GetStarships();
        /// <summary>
        /// List of the available starships
        /// </summary>
        List<StarShip> starships { get; set; }
    }
}
