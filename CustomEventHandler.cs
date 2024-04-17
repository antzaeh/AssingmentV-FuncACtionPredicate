using AssingmentV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static AssignmentV.Program;

namespace AssignmentV
{

    internal class CustomEventHandler
    {
        static StringBuilder log = new StringBuilder();
        SortedList<string, CustomEvent> events;
        public CustomEventHandler()
        {
            events = new SortedList<string, CustomEvent>();
            log.Append($"Captains log: {DateTime.Now} ");
        }

        public void AddEvent(string name, string type, string location, DateTime date, double price)
        {
            CustomEvent newEvent = new CustomEvent(name, type, location, date, price);
            events[name] = newEvent;
            //$"Event added: {name}. Events in collection: {events.Count}";
        }

        public string HandleEvent(HandleEvent handleEvent, string name, string type, string location, DateTime date, double price)
        {
            string result = handleEvent(name, type, location, date, price);
            log.AppendLine(result);
            return result;
        }

        public string DateSearch(Func<DateTime, CustomEvent, string> handler, DateTime FindDate)
        {
            foreach (var customevent in events)
            {
                if (handler(FindDate, customevent.Value) != null)
                {
                    return handler(FindDate, customevent.Value);
                    
                }
            }
            return ("Not found");
        }

        public void CheckPrice(Action<double, CustomEvent> handler, double maxPrice)
        {
            foreach (CustomEvent customEvent in events.Values)
            {
                if (customEvent.Price < maxPrice)
                {
                    handler(maxPrice, customEvent);
                }
            }
        }

        public string Search(Predicate<string> handler)
        {

            StringBuilder result = new StringBuilder();

            foreach (CustomEvent customEvent in events.Values)
            {
                if (handler(customEvent.Location))
                {
                    result.AppendLine(customEvent.ToString());
                }
            }

            return result.ToString();
        }
        public string DisplayALLEvents()
        {
            StringBuilder all = new StringBuilder();
            foreach (CustomEvent events in events.Values)
            {
                all.Append(events.ToString() + Environment.NewLine);
            }
            return all.ToString();
        }

        public static string Log
        {
            get
            {
                return log.ToString();
            }


        }
    }




}




