using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Challenge_3_b
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "RoomsWithComputers",
                routeTemplate: "api/rooms/computer/",
                defaults: new { controller = "Rooms", action = "RoomsWithComputers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "unused",
                routeTemplate: "api/rooms/unused/",
                defaults: new { controller = "Rooms", action = "unused", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "used",
               routeTemplate: "api/rooms/used/",
               defaults: new { controller = "Rooms", action = "used", id = RouteParameter.Optional }
           );



            config.Routes.MapHttpRoute(
                name: "Rooms",
                routeTemplate: "api/rooms",
                defaults: new { controller = "Rooms", action = "Get", category = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
    name: "Computers",
    routeTemplate: "api/computers",
    defaults: new { controller = "Computers", action = "Get", category = RouteParameter.Optional }
);
            config.Routes.MapHttpRoute(
    name: "Class",
    routeTemplate: "api/class",
    defaults: new { controller = "Class", action = "Get", category = RouteParameter.Optional }
    );

            config.Routes.MapHttpRoute(
    name: "ClassId",
    routeTemplate: "api/class/{id}",
    defaults: new { controller = "Class", action = "Get", id = RouteParameter.Optional }
    );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{category}",
                defaults: new { id = RouteParameter.Optional }
            );
           

        }
    }
}
