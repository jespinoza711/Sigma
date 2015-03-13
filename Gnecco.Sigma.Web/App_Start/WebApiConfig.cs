using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Gnecco.Sigma.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Logout
            config.Routes.MapHttpRoute(
                name: "Logout",
                routeTemplate: "api/Logout/{id}",
                defaults: new { controller = "Logout", id = RouteParameter.Optional }
            );

            //Usuario
            config.Routes.MapHttpRoute(
                name: "Usuario",
                routeTemplate: "api/Usuario/{id}",
                defaults: new { controller = "Usuario", id = RouteParameter.Optional }
            );

            //Inventario
            config.Routes.MapHttpRoute(
                name: "InventarioRest",
                routeTemplate: "api/Inventario/{id}",
                defaults: new { controller = "Inventario", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: null,
                routeTemplate: "api/Inventario/PostFormData/",
                defaults: new { controller = "Inventario", action = "PostFormData" }
            );

            // Nissan

            config.Routes.MapHttpRoute(
                name: "NissanRest",
                routeTemplate: "api/InformeInspeccion/Nissan/{id}",
                defaults: new { controller = "InformeInspeccionNissan", id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
              name: "CompletadosNissan",
              routeTemplate: "api/Completados/InformeInspeccion/Nissan/Completados/{id}",
              defaults: new { controller = "CompletadosNissanController", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: null,
               routeTemplate: "api/InformeInspeccionCompleto/Nissan/{id}",
               defaults: new { controller = "InformeInspeccionNissanCompletado", id = RouteParameter.Optional }
            );


            // Volkswagen

            config.Routes.MapHttpRoute(
               name: "VolkswagenRest",
               routeTemplate: "api/InformeInspeccion/Volkswagen/{id}",
               defaults: new { controller = "InformeInspeccionVolkswagen", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: null,
               routeTemplate: "api/InformeInspeccion/Volkswagen/Completados/{InformeInspeccionId}",
               defaults: new { controller = "InformeInspeccionVolkswagen", action = "Completados" }
            );

            config.Routes.MapHttpRoute(
               name: null,
               routeTemplate: "api/InformeInspeccionCompleto/Volkswagen/{id}",
               defaults: new { controller = "InformeInspeccionVolkswagenCompletado", id = RouteParameter.Optional }
            );

            // Ford

            config.Routes.MapHttpRoute(
               name: null,
               routeTemplate: "api/InformeInspeccionFordNuevo",
               defaults: new { controller = "InformeInspeccionFordNuevo" }
            );

            config.Routes.MapHttpRoute(
               name: null,
               routeTemplate: "api/InformeInspeccionCompleto/Ford/{id}",
               defaults: new { controller = "InformeInspeccionFordCompletado", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "FordRest",
               routeTemplate: "api/InformeInspeccion/Ford/{id}",
               defaults: new { controller = "InformeInspeccionFord", id = RouteParameter.Optional }
            );

            

            // Default

            //config.Routes.MapHttpRoute(
            //    name: "null",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
