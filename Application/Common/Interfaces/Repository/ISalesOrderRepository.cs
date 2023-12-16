using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface ISalesOrderRepository : IRepository<SalesOrder>
    {
        Task<bool> ProductExists(string productId);

        Task<bool> CustomerExists(string customerId);
    }
}