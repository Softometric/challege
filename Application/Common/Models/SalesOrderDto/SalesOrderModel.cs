using Domain.Enum;

namespace Application.Common.Models.SalesOrderDto
{
    public class SalesOrderModel
    {
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public string? CustomerId { get; set; }
    }

    public class SalesOrderRequestModel : SalesOrderModel
    {
        public OrderStatus Status { get; set; }
    }

    public class SalesOrderResponseModel : SalesOrderModel
    {
        public string? Id { get; set; }
        public string? Status { get; set;}
    }
}
