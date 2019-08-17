using Optimizer.Models.Vehicle;
using Optimizer.Models.Trip;
using System.Collections.Generic;
using System.Linq;
using Optimizer.Methods;
using Optimizer.Models;
using Optimizer.Models.Vehicles;

namespace Optimizer
{
    public static class BatchOptimizer
    {
        public static TripSummary Optimize(IEnumerable<ScheduledVehicle> vehicles, IEnumerable<ScheduledTrip> trips)
        {
            var earliestStartVehicleTime = vehicles.Min(st => st.VehicleStart);
            var latestStopVehicleTime = vehicles.Max(st => st.VehicleEnd);
            var tripSummary = new TripSummary();

            foreach (var trip in trips.OrderBy(ob => ob.ID))
            {
                if (trip.StartDateTime < earliestStartVehicleTime || trip.EndDateTime > latestStopVehicleTime)
                {                    
                    trip.Illegal = true;                    
                    continue;
                }                
                
                foreach (var vehicle in vehicles.OrderBy(ob => ob.ScheduledTrips.Count))
                {
                    //Check trip time against vehicle start time
                    if (vehicle.VehicleStart > trip.StartDateTime || vehicle.VehicleEnd < trip.EndDateTime) continue;

                    if (!vehicle.ScheduledTrips.Any() || 
                        vehicle.ScheduledTrips.Any(st => !trip.StartDateTime.InRange(st.StartDateTime, st.EndDateTime) && trip.StartDateTime >= st.EndDateTime))
                    {
                        vehicle.ScheduledTrips.Add(trip);
                        trip.VehicleID = vehicle.ID;
                        break;
                    }
                }

                if (trip.VehicleID == null)
                {
                    trip.WaitList = true;
                }
            }
            
            foreach (var vehicle in vehicles)
            {
                var vehicleTrips = vehicle.ScheduledTrips.OrderBy(ob => ob.StartDateTime).ToList();

                for (int i = 0; i < vehicleTrips.Count - 2; i++)
                {
                    var currentTripEnd = vehicleTrips[i].EndDateTime;
                    if ((vehicleTrips[i+1].StartDateTime-currentTripEnd).Minutes > 20)
                        vehicle.VehicleBreaks.Add(new ScheduledVehicleBreak { StartDateTime = currentTripEnd, EndDateTime = currentTripEnd.AddMinutes(20) });
                }
            }

            tripSummary.Trips = trips;
            tripSummary.Vehicles = vehicles;

            return tripSummary;
        }
    }
}
