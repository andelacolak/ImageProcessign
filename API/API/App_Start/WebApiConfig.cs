using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "Login",
               routeTemplate: "api/login",
               defaults: new { controller = "Account", action = "Login" }
               );

            config.Routes.MapHttpRoute(
               name: "Register",
               routeTemplate: "api/register",
               defaults: new { controller = "Account", action = "Register" }
               );

            config.Routes.MapHttpRoute(
               name: "Darken",
               routeTemplate: "api/darken",
               defaults: new { controller = "Image", action = "DarkenImage" }
               );

            config.Routes.MapHttpRoute(
               name: "Invert",
               routeTemplate: "api/invert",
               defaults: new { controller = "Image", action = "InvertColor" }
               );

            config.Routes.MapHttpRoute(
               name: "Grayscale",
               routeTemplate: "api/grayscale",
               defaults: new { controller = "Image", action = "ImageToGrayscale" }
               );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
