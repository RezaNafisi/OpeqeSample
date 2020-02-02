﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Opeqe.Sample.BLL.Services.GIS
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost hostWeb = new WebServiceHost(typeof(Opeqe.Sample.BLL.Services.GIS.Service));
            ServiceEndpoint ep = hostWeb.AddServiceEndpoint(typeof(Opeqe.Sample.BLL.Services.GIS.IService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = hostWeb.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;
            hostWeb.Open();
            Console.WriteLine("Service Host started @ " + DateTime.Now.ToString());
            Console.Read();
        }


    }
}
