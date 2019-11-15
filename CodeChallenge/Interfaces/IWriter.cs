#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace CodeChallenge.Interfaces
{
    /// <summary>
    /// Provides the mechanism for writing dirctly into the console with three different methods
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Used for writing general information
        /// Color is set to blue
        /// </summary>
        /// <param name="message">Info to be written</param>
        void Info(string message);
        /// <summary>
        /// Used for writing data information, such as star ships
        /// Color is set to white
        /// </summary>
        /// <param name="message">Data to be written</param>
        void data(string message);
        /// <summary>
        /// Used for writing any errors that might occur in the application
        /// Color is set to red
        /// </summary>
        /// <param name="message">Error message to be written</param>
        void Error(string message);
    }
}
