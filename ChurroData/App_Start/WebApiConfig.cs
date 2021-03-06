﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace ChurroData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
          
            // Web API routes
            config.MapHttpAttributeRoutes();

            GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


        }
    }
}
