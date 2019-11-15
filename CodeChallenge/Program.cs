#region Using
using CodeChallenge.Interfaces;
using SimpleInjector;
using Swapi.Interfaces;
using Swapi.Models;
using Swapi.Program;
using Swapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CodeChallenge
{
    /// <summary>
    /// Intiates the Executer class  to calculate the distance entered by the user
    /// The user can enter as many distance as he wants
    /// System will exit when user input "Exit" or "exit"
    /// </summary>
    class Program
    {
        static Container container;

        static void Main(string[] args)
        {
            Task.WaitAll(Run(args));
        }

        static async Task Run(string[] args)
        {
            try
            {
                Construct();

                Executer exc = container.GetInstance<Executer>();

                string input = string.Empty;
                do
                {
                    Console.Write("Enter distance: ");
                    input = Console.ReadLine();

                   
                    long distance;
                    if (long.TryParse(input, out distance))
                    {
                        await exc.Intialize();

                        exc.Execute(distance);
                    }
                } while (input.ToLower() != "exit");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
        private static void Construct()
        {
            container = new Container();
            container.Options.DefaultLifestyle = Lifestyle.Singleton;
            HttpClient http = new HttpClient();

            http.BaseAddress = new Uri("https://swapi.co");

            container.Register<IWriter, Writer>();
            container.Register<IStarship, StarShip>();
            container.Register<IStarshipMeasures, StarShip>();
            container.Register<IStopsCalculator, StopsCalculator>();
            container.Register<IStarshipService>(() => new StarShipService(http));

            container.Verify();
        }
    }
}
