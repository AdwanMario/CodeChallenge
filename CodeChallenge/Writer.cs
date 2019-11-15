#region Using
using CodeChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CodeChallenge
{
    public class Writer : IWriter
    {
        #region Methods
        public void Error(string message)
        {
            Write(message, ConsoleColor.Red);
            Console.Write(Environment.NewLine);
        }
         

        public void Info(string message)
        {
            Write(message, ConsoleColor.Blue);
            
            Console.Write(Environment.NewLine);
        }

        private void Write(object value, ConsoleColor color)
        {
            var foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.Write(value);

            Console.ForegroundColor = foregroundColor;
        }

        public void data(string message)
        {
            Write(message, ConsoleColor.White);

            Console.Write(Environment.NewLine);
        }
        #endregion
    }
}
