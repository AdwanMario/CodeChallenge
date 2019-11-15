using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Models
{
    /// <summary>
    /// This class represents the main fields coming from the Swapi API
    /// All Swapi Apis have count, next and results fields
    /// Results is of type generic list
    /// </summary>
    /// <typeparam name="T">Depends on which API request we are calling, where the results field varies between different request, like "starships", "people"</typeparam>
    public class Swapi<T>
    {
        /// <summary>
        /// Count of all the results
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// The url of the next page for the results, the API swapi.co splits the data into seperate pages having 10 records in each page 
        /// If the next url is null means we have come to the end of pages
        /// </summary>
        public string next { get; set; }
        /// <summary>
        /// represents the result of the data we are asking for from the API
        /// </summary>
        public List<T> results { get; set; }
    }
}
