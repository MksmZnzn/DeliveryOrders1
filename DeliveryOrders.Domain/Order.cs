using System.ComponentModel.DataAnnotations;

namespace DeliveryOrders.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public double Weight { get; set; }
        [Required]
        public string? District { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
