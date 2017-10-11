using Microsoft.Practices.Unity;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Repositories;
using System.Web.Http;
using Unity.WebApi;

namespace Statecraft.Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IGameRepository, GameRepository>();
            container.RegisterType<IOrdersRepository, OrdersRepositoryFake>();
            container.RegisterType<IPlayerRepository, PlayerRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}