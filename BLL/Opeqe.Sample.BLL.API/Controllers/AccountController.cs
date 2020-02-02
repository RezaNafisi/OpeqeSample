using Opeqe.Sample.Common.Log;
using Opeqe.Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Opeqe.Sample.BLL.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
            try
            {
                var res = await WebApiApplication.command.Register(model);
                if (res.IsSuccessful)
                {
                    return Ok();
                }
                return BadRequest(res.Message);
            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route(nameof(Echo))]
        [Authorize]
        public  IHttpActionResult Echo()
        {
            return Ok();
        }
    }
}
