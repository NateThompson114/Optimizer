using System;
using System.Linq;
using static System.Console;

namespace Optimizer
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine("SUMMARY\n~~~~~~~~~~~~~");
                        
            var tripSummary = BatchOptimizer.Optimize(TestData.TestData.vehicles, TestData.TestData.Trips);

            const string endStatement = "Trips total.";
            WriteLine($"{tripSummary.Trips.Count()} {endStatement}");
            WriteLine($"{tripSummary.Trips.Where(cid => cid.VehicleID > 0).Count()} Scheduled {endStatement}");
            WriteLine($"{tripSummary.Trips.Where(cid => cid.WaitList == true).Count()} Waitlisted {endStatement}");
            WriteLine($"{tripSummary.Trips.Where(cid => cid.Illegal == true).Count()} Illegal {endStatement}");

            
            foreach(var vehicle in tripSummary.Vehicles) WriteLine($"Car {vehicle.ID} had {vehicle.ScheduledTrips.Count()} rides.");
        }
    }
}
