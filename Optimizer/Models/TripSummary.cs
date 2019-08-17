using Optimizer.Models.Trip;
using Optimizer.Models.Vehicle;
using System;
using System.Collections.Generic;

namespace Optimizer.Models
{
    public class TripSummary
    {
        public DateTime TripDateTime { get; set; }

        public IEnumerable<ScheduledTrip> Trips { get; set; }
        public IEnumerable<ScheduledVehicle> Vehicles { get; set; }
    }
}
