using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Interfaces
{
    /// <summary>
    /// Represents the standard required fields of a starship coming from the <see href="https://swapi.co/">API</see>
    /// </summary>
    public interface IStarship
    {
        /// <summary>
        /// Represent the name of the starship
        /// </summary>
        string name { get; set; }
        /// <summary>
        /// Represents the Maximum number of Megalights this starship can travel in a standard hour.
        /// A "Megalight" is a standard unit of distance and has never been defined before within the Star Wars universe. This figure is only really useful for measuring the difference in speed of starships. We can assume it is similar to AU, the distance between our Sun (Sol) and Earth.
        /// </summary>
        string MGLT { get; set; }
        /// <summary>
        /// The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
        /// </summary>
        string consumables { get; set; }
    }
}
