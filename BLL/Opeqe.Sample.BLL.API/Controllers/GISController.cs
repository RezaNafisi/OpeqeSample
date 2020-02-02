using Newtonsoft.Json;
using Opeqe.Sample.BLL.API.Classes;
using Opeqe.Sample.Common.Log;
using Opeqe.Sample.Common.Models;
using Opeqe.Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Opeqe.Sample.BLL.API.Controllers
{

    [RoutePrefix("api/GIS")]
    [Authorize]
    public class GISController : ApiController
    {
        [HttpPost]
        [Route(nameof(GetDistance))]
        public async Task<IHttpActionResult> GetDistance(DistanceBindingModel model)
        {
            try
            {
                var url= ConfigurationManager.AppSettings["ServiceUrl"];
                var jres = await Proxy.SendJsonGetAsync(url, model.OriginLatitude.ToString(), model.OriginLongitude.ToString()
                    , model.DestinationLatitude.ToString(), model.DestinationLongitude.ToString());
                var res = JsonConvert.DeserializeObject<dynamic>(jres);
                string _distance = res.Distance;
                _distance = _distance.Replace("{", "").Replace("}", "");
                double distance = 0;
                if (double.TryParse(_distance,out distance))
                {
                   await WebApiApplication.command.AddRequest(User.Identity.Name, new Distance {
                       CalculatedDistance=distance,
                       DestinationLatitude=model.DestinationLatitude,
                       DestinationLongitude=model.DestinationLongitude,
                       OriginLatitude=model.OriginLatitude,
                       OriginLongitude=model.OriginLongitude
                   });
                }
                return Ok(_distance);

            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route(nameof(GetHistory))]
        public async Task<IHttpActionResult> GetHistory()
        {
            try
            {
                var res = await WebApiApplication.command.GetRequest(User.Identity.Name);
                if (res.IsSuccessful)
                {
                    return Ok(res.Data);
                }
                else
                {
                    if (res.Message== "User does not exist.")
                    {
                        return Unauthorized();
                    }
                    return BadRequest(res.Message);
                }

            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return InternalServerError();
            }
        }
    }
}
