using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace practice3
{
    internal class Program
    {
        //задание 1
        static void Month()
        {
            string[] month = new[] { "June", "July", "May", "December", "January", "April",
                "August", "Febrary", "September", "March", "October", "November" };

            //запрос 1

            var n = 5;
            var selectedMonth = month.Where(m => m.Length == n);
            foreach (string mon in selectedMonth)
                Console.WriteLine(mon);

            Console.WriteLine();

            //запрос 2

            var choosenMonth = month.Where((m) => (m == "June") || (m == "July") || (m == "August")
            || (m == "December") || (m == "January") || (m == "Febrary"));

            foreach (string mon in choosenMonth)
                Console.WriteLine(mon);

            Console.WriteLine();

            //запрос 3

            var sortedMonth = month.OrderBy(m => m);
            foreach (string mon in sortedMonth)
                Console.WriteLine(mon);

            Console.WriteLine();

            //запрос 4

            var num = month.Where(m => m.Length >= 4 && m.Contains('u')).Count();
            Console.WriteLine(num);
        }

        //задание 2
        class Airline
        {
            public string Destination { get; private set; }

            public int FlightNumber { get; private set; }

            public DateTime DepartureTime { get; private set; }

            public DayOfWeek DayWeek { get; private set; }

            public Airline (string destination, int flightNumber, DateTime departureTime)
            {
                Destination = destination;
                if (flightNumber < 0)
                    throw new Exception();
                FlightNumber = flightNumber;
                DepartureTime = new DateTime(departureTime.Year, departureTime.Month, departureTime.Day,
                    departureTime.Hour, departureTime.Minute, departureTime.Second);
                DayWeek = DepartureTime.DayOfWeek;
            }
        }

        static void Main(string[] args)
        {
            Month();
            Console.WriteLine();

            //задание 3

            var airlines = new List<Airline>()
            {
                new Airline("Москва", 3212, new DateTime(2022, 12, 7, 15, 15, 00)),
                new Airline("Екатеринбург", 4586, new DateTime(2022, 11, 28, 1, 50, 00)),
                new Airline("Сочи", 913, new DateTime(2022, 12, 26, 12, 35, 00)),
                new Airline("Москва", 8655, new DateTime(2022, 11, 8, 4, 10, 00)),
                new Airline("Новосибирск", 672, new DateTime(2023, 6, 16, 19, 00, 00)),
                new Airline("Новосибирск", 5934, new DateTime(2023, 1, 9, 1, 40, 00)),
                new Airline("Москва", 7645, new DateTime(2022, 11, 4, 00, 00, 00))
            };

            // задание 4
            //запрос 1
            var destination = "Новосибирск";
            var airDestination = airlines.Where(airline => airline.Destination == destination).ToList();

            foreach (var airline in airDestination)
                Console.WriteLine($"Пункт назначения {airline.Destination}, " +
                    $"Номер рейса {airline.FlightNumber}, " +
                    $"Время вылета {airline.DepartureTime}, " +
                    $"День недели {airline.DayWeek}.");
            Console.WriteLine();

            //запрос 2

            var dayOfWeek1 = DayOfWeek.Wednesday;
            var airDayOfWeek = airlines.Where(air => air.DayWeek == dayOfWeek1).Count();
            Console.WriteLine(airDayOfWeek);

            Console.WriteLine();

            //запрос 3
            var dayOfWeek2 = DayOfWeek.Monday;            
            var airEarlyMonday = airlines.Where(air => air.DayWeek == dayOfWeek2)
                .OrderBy(a => a.DepartureTime.ToLongTimeString()).First();
            Console.WriteLine($"Пункт назначения {airEarlyMonday.Destination}, " +
                $"Номер рейса {airEarlyMonday.FlightNumber}, " +
                $"Время вылета {airEarlyMonday.DepartureTime}, " +
                $"День недели {airEarlyMonday.DayWeek}.");

            Console.WriteLine();

            //запрос 4

            var dayOfWeek3 = DayOfWeek.Friday;
            var airEarlyFridayWednesday = airlines.Where(air => air.DayWeek == dayOfWeek1 || air.DayWeek == dayOfWeek3)
                .OrderByDescending(a => a.DepartureTime.ToLongTimeString()).First();

            Console.WriteLine($"Пункт назначения {airEarlyFridayWednesday.Destination}, " +
                $"Номер рейса {airEarlyFridayWednesday.FlightNumber}, " +
                $"Время вылета {airEarlyFridayWednesday.DepartureTime}, " +
                $"День недели {airEarlyFridayWednesday.DayWeek}.");

            Console.WriteLine();

            //запрос 5
            var orderedAir = airlines.OrderBy(air => air.DepartureTime).ToList();
            foreach (var airline in orderedAir)
                Console.WriteLine($"Пункт назначения {airline.Destination}, " +
                    $"Номер рейса {airline.FlightNumber}, " +
                    $"Время вылета {airline.DepartureTime}, " +
                    $"День недели {airline.DayWeek}.");
        }
    }
}
