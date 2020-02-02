using System;
using System.Collections.Generic;
using System.Text;

namespace Opeqe.Sample.DAL.Entities
{
    public class Distance
    {
        public int DistanceId { get; set; }
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
        public double CalculatedDistance { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
