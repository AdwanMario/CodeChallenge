#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace Swapi.Program
{
    /// <summary>
    /// Represents the definition of the enums in the application
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Represents the enum containing the Unit of measures available
        /// </summary>
        public enum UOM
        {
            Hour,
            Day,
            Week,
            Month,
            Year,
            Invalid
        }
    }
}
