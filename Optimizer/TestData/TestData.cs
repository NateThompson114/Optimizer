using Optimizer.Models.Vehicle;
using Optimizer.Models.Trip;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Optimizer.TestData
{
    public static class TestData
    {
        public static IEnumerable<ScheduledVehicle> vehicles = new List<ScheduledVehicle>()
        {
            new ScheduledVehicle
            {
                ID = 1,
                VehicleStart = new DateTime(2020,9,1,9,30,0),
                VehicleEnd = new DateTime (2020,9,1,14,30,0),
            },
            new ScheduledVehicle
            {
                ID = 2,
                VehicleStart = new DateTime(2020,9,1,11,0,0),
                VehicleEnd = new DateTime (2020,9,1,19,0,0),
            },
            new ScheduledVehicle
            {
                ID = 3,
                VehicleStart = new DateTime(2020,9,1,14,30,0),
                VehicleEnd = new DateTime (2020,9,1,22,0,0),
            }
        };

        public static IEnumerable<ScheduledTrip> Trips {
            get
            {
                return MockTrips();
                //return GetTripsFromJSON();
            }
        }

        private static IEnumerable<ScheduledTrip> MockTrips ()
        {
            int month = 9;
            int day = 1;
            int year = 2020;
            int numOfTrips = 60;
            List<ScheduledTrip> returnTrips = new List<ScheduledTrip>();
            while (numOfTrips > 0)
            {
                Random rng = new Random();
                int hour = rng.Next(10, 22);
                int minute = rng.Next(0, 60);
                int second = 0;
                returnTrips.Add (
                    new ScheduledTrip
                    {
                        StartDateTime = new DateTime(year, month, day, hour, minute, second),
                        EndDateTime = new DateTime(year, month, day, hour, minute, second).AddMinutes(rng.Next(10, 45)),
                        ID = numOfTrips
                    });
                numOfTrips--;
            }
            return returnTrips;
        }

        private static IEnumerable<ScheduledTrip> GetTripsFromJSON()
        {
            string s = File.ReadAllText($"{Directory.GetCurrentDirectory()}/TripsToJson.txt", Encoding.UTF8);
            return JsonConvert.DeserializeObject<IEnumerable<ScheduledTrip>>(s);
        }
        
    }
}
