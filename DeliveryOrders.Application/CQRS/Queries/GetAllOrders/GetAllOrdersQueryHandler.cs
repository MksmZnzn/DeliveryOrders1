using DeliveryOrders.Application.Interfaces.Repositories;
using DeliveryOrders.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Application.CQRS.Queries
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private readonly IDeliveryOrdersRepository _deliveryOrdersRepository;
        public GetAllOrdersQueryHandler(IDeliveryOrdersRepository deliveryOrdersRepository)
        {
            _deliveryOrdersRepository = deliveryOrdersRepository;
        }

        public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _deliveryOrdersRepository.GetAllOrdersAsync();
        }
    }
}
