using Swapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Interfaces
{
    /// <summary>
    /// Respresents the fields required for calculating measures for each starship
    /// </summary>
    public interface IStarshipMeasures
    {
        /// <summary>
        /// Number of stops a starship need to resuply covering a certain distance
        /// </summary>
        long stops { get; set; }
        /// <summary>
        /// Represents a converted field for MGLT, since MGLT coming from the API is string
        /// </summary>
        long MGLTConverted { get; set; }
        /// <summary>
        /// Represents details of the consumption after being split into two units, "Time" and "Unit of measure"
        /// </summary>
        ConsumptionDetail consumptiondetail { get; set; }
    }
}
