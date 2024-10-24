using DeliveryOrders.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Application.CQRS.Queries
{
    public class GetFilteredOrdersQuery : IRequest<List<Order>>
    {
        public string District { get; }
        public DateTime FromTime { get; }
        

        public GetFilteredOrdersQuery(string district, DateTime fromTime)
        {
            District = district;
            FromTime = fromTime;
            
        }
    }
}
