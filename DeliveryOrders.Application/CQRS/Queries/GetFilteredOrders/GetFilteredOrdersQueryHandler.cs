using DeliveryOrders.Application.Interfaces.Repositories;
using DeliveryOrders.Domain;
using MediatR;
using DeliveryOrders.Application.Interfaces;

namespace DeliveryOrders.Application.CQRS.Queries
{
    public class GetFilteredOrdersQueryHandler : IRequestHandler<GetFilteredOrdersQuery, List<Order>>
    {
        private readonly IDeliveryOrdersRepository _deliveryOrdersRepository;
        public GetFilteredOrdersQueryHandler(IDeliveryOrdersRepository deliveryOrderRepository)
        {
            _deliveryOrdersRepository = deliveryOrderRepository;
        }

        public async Task<List<Order>> Handle(GetFilteredOrdersQuery query, CancellationToken cancellation)
        {
            // Получаем все заказы асинхронно
            return await _deliveryOrdersRepository.GetFilteredOrdersAsync(query.District, query.FromTime, query.ToTime);


            
        }
    }
}
