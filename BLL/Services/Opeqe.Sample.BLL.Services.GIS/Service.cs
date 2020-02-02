using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Opeqe.Sample.BLL.Services.GIS
{
    public class Service : IService
    {
        bool IsInRange(double d)
        {
            if (d<-90 || d>90)
            {
                return false;
            }
            return true;
        }

        [return: MessageParameter(Name = "Data")]
        public string CalcDestination(string oLat, string oLong, string dLat, string dLong)
        {
            double _olat = 0;
            double _olong = 0;
            double _dlat = 0;
            double _dlong = 0;

            if (!double.TryParse(oLat, out _olat))
            {
                return "The Origin Latitude is incorrect";
            }
            if (!double.TryParse(oLong, out _olong))
            {
                return "The Origin Longitude is incorrect";
            }
            if (!double.TryParse(dLat, out _dlat))
            {
                return "The Destination Latitude is incorrect";
            }
            if (!double.TryParse(dLong, out _dlong))
            {
                return "The Destination Longitude is incorrect";
            }

            if (!IsInRange(_olat))
            {
                return "Origin Latitude is not in range";
            }

            if (!IsInRange(_olong))
            {
                return "Origin Longitude is not in range";
            }

            if (!IsInRange(_dlat))
            {
                return "Destination Latitude is not in range";
            }

            if (!IsInRange(_dlong))
            {
                return "Destination Longitude is not in range";
            }

            var sCoord = new GeoCoordinate(_olat, _olong);
            var eCoord = new GeoCoordinate(_dlat, _dlong);

            return sCoord.GetDistanceTo(eCoord).ToString();

        }
    }
}
