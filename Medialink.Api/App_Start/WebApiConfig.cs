﻿using MediaLink.Lib;
using MediaLink.Lib.RestClientFactory;
using MediaLink.Lib.RestRequestFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Medialink.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<MathWebClient>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestClientFactory, RestClientFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestRequestFactory, RestRequestFactory>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
