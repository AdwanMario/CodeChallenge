using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Interfaces
{
    /// <summary>
    /// Represents the calculation methods needed to be done on each starship 
    /// </summary>
    public interface IStopsCalculator
    {
        /// <summary>
        /// Calculates the number of stops for a starship
        /// Divides the distance parameter by, the maximum number of hours needed for a starship resuply multiplied by the MGLT
        /// </summary>
        /// <param name="starship">Represents the current starship its stops is being calculated</param>
        /// <param name="distance">Represents the distance that needs to be covered</param>
        void stops(IStarshipMeasures starship, long distance);
        /// <summary>
        /// Converts the consumables time into hours
        /// The need to convert all consumables into hours is because MGLT is represented by hours
        /// </summary>
        /// <param name="starship">Represent the current starship</param>
        /// <returns></returns>
        long hours(IStarshipMeasures starship);
    }
}
