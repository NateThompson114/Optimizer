using System;
using System.Collections.Generic;
using System.Text;

namespace Optimizer.Models.Trip
{
    public class ScheduledTrip
    {
        public int ID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int? VehicleID { get; set; }
        public bool? Illegal { get; set; }

        public bool? WaitList { get; set; }
    }
}
