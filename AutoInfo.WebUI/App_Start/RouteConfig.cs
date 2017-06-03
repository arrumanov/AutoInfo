﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoInfo.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Указываем, что все ресурсы ext.net нужно игнорировать
            routes.IgnoreRoute("{extnet-root}/{extnet-file}/ext.axd");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Car", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
