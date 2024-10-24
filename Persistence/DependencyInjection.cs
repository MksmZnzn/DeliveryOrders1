using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryOrders.Application.Interfaces.Repositories;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            // Регистрируем репозиторий заказов
            
            services.AddRepositories();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IDeliveryOrdersRepository, DeliveryOrdersRepository>();

            return services;
        }
    }
}
