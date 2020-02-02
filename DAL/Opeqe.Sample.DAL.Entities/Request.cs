using System;
using System.Collections.Generic;
using System.Text;

namespace Opeqe.Sample.DAL.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public int DistanceId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Distance Distance { get; set; }
        public virtual User User { get; set; }
    }
}
