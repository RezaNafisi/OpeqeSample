using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Opeqe.Sample.BLL.API.Classes
{
    public class Proxy
    {
        public async static Task<string> SendJsonPostAsync(string url, string jsonBody)
        {
            var result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
            }

            var httpResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
        public async static Task<string> SendJsonGetAsync(string url,params string[] param)
        {
            var result = "";
            var query ="/"+ param.Aggregate((a, b) => a + "/" + b);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url+query);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";


            var httpResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}