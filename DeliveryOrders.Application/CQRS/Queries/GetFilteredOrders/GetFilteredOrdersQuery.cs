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
        [Required]
        public string District { get; }
        public DateTime FromTime { get; }
        public DateTime ToTime { get; }

        public GetFilteredOrdersQuery(string district, DateTime fromTime, DateTime toTime)
        {
            District = district;
            FromTime = fromTime;
            ToTime = toTime;
        }
    }
}
