using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Swapi.Program.Enums;

namespace Swapi.Models
{
    /// <summary>
    /// Details for the consumables
    /// Consumables field from the <see href="https://swapi.co/">API</see> is a string value with number of certain duration
    /// Duration is represented by Hours, Days, Weeks, Months or Years
    /// </summary>
    public class ConsumptionDetail
    {
        /// <summary>
        /// Represents the Time of the consumables
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// Represents the Unit of measure of the consumables
        /// <seealso cref="UOM"/>
        /// </summary>
        public UOM uom { get; set; }
    }
}
