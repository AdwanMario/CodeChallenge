#region Using
using Swapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace Swapi.Program
{
    public class StopsCalculator : IStopsCalculator
    {
        #region Methods
        /// <summary>
        /// Calculates the number of stops for a starship
        /// Divides the distance parameter by, the maximum number of hours needed for a starship resuply multiplied by the MGLT
        /// </summary>
        /// <param name="starship">Represents the current starship its stops is being calculated</param>
        /// <param name="distance">Represents the distance that needs to be covered</param>
        public void stops(IStarshipMeasures starship, long distance)
        {
            if(starship.consumptiondetail.uom == Enums.UOM.Invalid || 
                starship.consumptiondetail.Time == -1 || starship.MGLTConverted == 0)
            {
                starship.stops = 0;
                return;
            }

            starship.stops = (long)(distance / (this.hours(starship) * starship.MGLTConverted));

        }
        /// <summary>
        /// Converts the consumables time into hours
        /// The need to convert all consumables into hours is because MGLT is represented by hours
        /// </summary>
        /// <param name="starship">Represent the current starship</param>
        /// <returns>Converted time into hours depending on the unit of measure</returns>
        public long hours(IStarshipMeasures starship)
        {
            if(starship.consumptiondetail == null)
            {
                throw new ArgumentNullException(nameof(starship.consumptiondetail));
            }

            switch (starship.consumptiondetail.uom)
            {
                case Enums.UOM.Hour:
                    return starship.consumptiondetail.Time;
                case Enums.UOM.Day:
                    return starship.consumptiondetail.Time * 24;
                case Enums.UOM.Week:
                    return starship.consumptiondetail.Time * 168;
                case Enums.UOM.Month:
                    return starship.consumptiondetail.Time * 730;
                case Enums.UOM.Year:
                    return starship.consumptiondetail.Time * 8760;
                default:
                    return 0;
            }    
        }
        #endregion
    }
}
