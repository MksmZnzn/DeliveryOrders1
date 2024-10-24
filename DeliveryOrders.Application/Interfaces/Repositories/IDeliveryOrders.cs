using DeliveryOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Application.Interfaces.Repositories
{
    public interface IDeliveryOrdersRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List <Order>> GetFilteredOrdersAsync(String diistrict, DateTime dateFrom);
    }
}
