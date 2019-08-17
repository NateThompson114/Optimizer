using Newtonsoft.Json;
using Optimizer.Models.Trip;
using Optimizer.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optimizer.Models.Vehicle
{
    public class ScheduledVehicle
    {
        public int ID { get; set; }
        [JsonProperty("vehicleStart")]
        public DateTime VehicleStart { get; set; }
        [JsonProperty("vehicleEnd")]
        public DateTime VehicleEnd { get; set; }
        public List<ScheduledTrip> ScheduledTrips { get; set; }
        public List<ScheduledVehicleBreak> VehicleBreaks { get; set; }

        public ScheduledVehicle()
        {
            ScheduledTrips = new List<ScheduledTrip>();
            VehicleBreaks = new List<ScheduledVehicleBreak>();
        }
    }
}
