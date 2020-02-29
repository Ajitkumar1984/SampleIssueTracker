using AJ.IssueTracker.Business.Abstraction;
using AJ.IssueTracker.Business.Services;
using AJ.IssueTracker.DataAccess;
using AJ.IssueTracker.WebApi.App_Start;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace AJ.IssueTracker.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IIssueTrackerService, IssueTrackerService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<INotesService, NotesService>();
            container.RegisterType<IssuetrackerContext>(new HierarchicalLifetimeManager());
            var mapperConfig = PropertyMapper.InitializeAutoMapper();
            var mapper = mapperConfig.CreateMapper();
            container.RegisterType<IMapper, Mapper>(new InjectionConstructor(mapperConfig));

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
