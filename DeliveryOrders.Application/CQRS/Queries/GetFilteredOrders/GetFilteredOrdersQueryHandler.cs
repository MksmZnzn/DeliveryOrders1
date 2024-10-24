using DeliveryOrders.Application.Interfaces.Repositories;
using DeliveryOrders.Domain;
using MediatR;
using DeliveryOrders.Application.Interfaces;

namespace DeliveryOrders.Application.CQRS.Queries
{
    public class GetFilteredOrdersQueryHandler : IRequestHandler<GetFilteredOrdersQuery, List<Order>>
    {
        private readonly IDeliveryOrdersRepository _orderRepository;

        public GetFilteredOrdersQueryHandler(IDeliveryOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetFilteredOrdersQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _orderRepository.GetAllOrdersAsync();
        
            // Фильтрация заказов по району и времени
            var filteredOrders = allOrders
                .Where(order => order.District == request.District &&
                                order.DeliveryTime >= request.FromTime &&
                                order.DeliveryTime <= request.FromTime.AddMinutes(30))
                .ToList();

            return filteredOrders;
        }
    }
}
