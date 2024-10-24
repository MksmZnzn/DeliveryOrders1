using DeliveryOrders.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Application.CQRS.Queries
{
    public class GetAllOrdersQuery : IRequest<List<Order>>
    {

    }
}
