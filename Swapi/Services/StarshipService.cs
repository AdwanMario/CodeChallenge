#region Using
using Newtonsoft.Json;
using Swapi.Interfaces;
using Swapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace Swapi.Services
{
    public class StarShipService : IStarshipService
    {
        /// <summary>
        /// Used to call the api service
        /// </summary>
        HttpClient http;
        /// <summary>
        /// Invoked when a new instance is created.
        /// This instance is created using SimpleInjector DI, and inject HttpClient into the new instance.
        /// </summary>
        /// <param name="_http"></param>
        public StarShipService(HttpClient _http)
        {
            this.http = _http;
        }
        /// <summary>
        /// List of available starships
        /// </summary>
        public List<StarShip> starships
        {
            get;set;
        }
        /// <summary>
        /// Calls the Swapi Api requesting all starships.
        /// The request is deserialized into the Model swapi.
        /// Calls to the api keeps happening so we get all the available pages of data from swapi
        /// </summary>
        /// <returns>List of the available starships</returns>
        public async Task<List<StarShip>> GetStarships()
        {
            string response;
            Swapi<StarShip> swapi = new Swapi<StarShip>();
            starships = new List<StarShip>();
            response = await http.GetStringAsync("/api/starships");
            swapi = JsonConvert.DeserializeObject<Swapi<StarShip>>(response);
            starships.AddRange(swapi.results);
            while (swapi.next != null)
                {
                    response = await http.GetStringAsync(swapi.next);
                    swapi = JsonConvert.DeserializeObject<Swapi<StarShip>>(response);
                    starships.AddRange(swapi.results);
                };
            return starships;
            //return starships;
        }
    }
}
