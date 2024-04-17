using AssingmentV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentV
{
    internal class Program
    {
        public delegate string HandleEvent(string name, string type, string location, DateTime date, double price);
        static void Main(string[] args)
        {
            CustomEventHandler handler = new CustomEventHandler();


            handler.AddEvent("Event1", "Sport", "HallA", new DateTime(2001, 1, 1), 73.00);
            handler.AddEvent("Event2", "Music", "HallB", new DateTime(2022, 2, 2), 69.00);
            handler.AddEvent("Event3", "Other", "HallC", new DateTime(2033, 3, 3), 420.00);

            Console.WriteLine("Search 1.1.2001");
            Console.WriteLine(handler.DateSearch((date, CE) => $"Event on {date:yyyy-MM-dd}: {CE}", new DateTime(2001, 1, 1)));

            Console.WriteLine("Events under 100");
            handler.CheckPrice((price, CE) => Console.WriteLine($"Event with price less than {price} {CE}"), 100.0);

            Console.WriteLine("Search location HallA");
            Console.WriteLine(handler.Search(location => location == "HallA"));

            Console.WriteLine(CustomEventHandler.Log);

        }
    }
}
