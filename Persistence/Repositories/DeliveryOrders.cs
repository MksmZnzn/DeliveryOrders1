using DeliveryOrders.Application.Interfaces.Repositories;
using DeliveryOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class DeliveryOrdersRepository : IDeliveryOrdersRepository
{

    private List<Order> orders;

    public DeliveryOrdersRepository()
    {
        orders = new List<Order>()
        {
            new Order { OrderId = Guid.NewGuid(), DeliveryTime = DateTime.Now, District = "sdsda", Weight = 2.4 },
            new Order { OrderId = Guid.NewGuid(), DeliveryTime = DateTime.Now, District = "sdsda", Weight = 2.1 },
            new Order { OrderId = Guid.NewGuid(), DeliveryTime = DateTime.Now, District = "dfdfdf", Weight = 3.5 },
            new Order { OrderId = Guid.NewGuid(), DeliveryTime = DateTime.Now, District = "jhjujuj", Weight = 1.2 }
        };
    }

    public async Task<List<Order>> GetAllOrdersAsync() => await Task.FromResult(orders);
    public async Task<List<Order>> GetFilteredOrdersAsync(string diistrict, DateTime dateFrom)
    {
        DateTime timeRangeEnd = dateFrom.AddMinutes(30);

        var filteredOrders = orders.Where(o => o.District == diistrict
                                               && o.DeliveryTime >= dateFrom
                                               && o.DeliveryTime <= timeRangeEnd)
            .ToList();
        return await Task.FromResult(filteredOrders);
    }
}
