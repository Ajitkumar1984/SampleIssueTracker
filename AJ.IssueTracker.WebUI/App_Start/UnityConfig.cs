using AJ.IssueTracker.Services;
using AJ.IssueTracker.Services.Abstraction;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AJ.IssueTracker.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ITrackerService, TrackerService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}