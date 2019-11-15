using Swapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Models
{
    public class StarShip: IStarship, IStarshipMeasures
    {
        public StarShip()
        {
            this.consumptiondetail = new ConsumptionDetail();
        }
        /// <summary>
        /// Name of the starship
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The Maximum number of Megalights this starship can travel in a standard hour. A "Megalight" is a standard unit of distance and has never been defined before within the Star Wars universe. This figure is only really useful for measuring the difference in speed of starships. We can assume it is similar to AU, the distance between our Sun (Sol) and Earth. 
        /// When this field is being set from the API it will automatically convert the string value into long if its possible and fill it in MGLTConverted
        /// </summary>
        private string _mglt;
        public string MGLT {
            get {
                return _mglt;
            } set {
                _mglt = value;
                long _mgltconv;
                if (long.TryParse(_mglt, out _mgltconv))
                {
                    MGLTConverted = _mgltconv;
                }else
                {
                    MGLTConverted = 0;
                }
            }
        }

        /// <summary>
        /// The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
        /// When this field is being set from the API it will automatically convert the string value into the class ConsumptionDetails, splitting the string value into time and unit of measure
        /// </summary>
        private string _consumables;
        public string consumables {
            get { return _consumables; }
            set {
                _consumables = value.ToString();
                var cons = _consumables.Split(' ');
                
                if(cons.Count() != 2)
                {
                    this.consumptiondetail.Time = -1;
                    this.consumptiondetail.uom = Program.Enums.UOM.Invalid;
                    return;
                }

                switch (cons[1].ToString().ToLower())
                {
                    case ("hour"):
                    case ("hours"):
                        this.consumptiondetail.uom = Program.Enums.UOM.Hour;
                        break;
                    case ("day"):
                    case ("days"):
                        this.consumptiondetail.uom = Program.Enums.UOM.Day;
                        break;
                    case ("week"):
                    case ("weeks"):
                        this.consumptiondetail.uom = Program.Enums.UOM.Week;
                        break;
                    case ("month"):
                    case ("months"):
                        this.consumptiondetail.uom = Program.Enums.UOM.Month;
                        break;
                    case ("year"):
                    case ("years"):
                        this.consumptiondetail.uom = Program.Enums.UOM.Year;
                        break;
                    default:
                        this.consumptiondetail.uom = Program.Enums.UOM.Invalid;
                        break;
                }
                int time;
                if (int.TryParse(cons[0], out time)) {
                    this.consumptiondetail.Time = time;
                }
                else
                {
                    this.consumptiondetail.Time = -1;
                }
            }
        }
        /// <summary>
        /// Represents details of the consumption after being split into two units, "Time" and "Unit of measure"
        /// </summary>
        public ConsumptionDetail consumptiondetail { get; set; }
        /// <summary>
        /// Number of stops a starship need to resuply covering a certain distance
        /// </summary>
        public long stops { get; set; }

        /// <summary>
        /// Represents a converted field for MGLT, since MGLT coming from the API is string
        /// </summary>
        public long MGLTConverted { get; set; }
    }
}
