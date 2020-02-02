using Opeqe.Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Opeqe.Sample.BLL.Services.GIS
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "calc/{oLat}/{oLong}/{dLat}/{dLong}")]
        [return: MessageParameter(Name = "Distance")]
        string CalcDestination(string oLat, string oLong, string dLat, string dLong);
    }
}
