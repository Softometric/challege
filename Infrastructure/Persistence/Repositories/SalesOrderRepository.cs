
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Factories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(SalesDbContext context) : base(context)
        {
        }

        public async Task<bool> ProductExists(string productId)
        {
            return await context.Products.AnyAsync(c => c.Id == productId);
        }


        public async Task<bool> CustomerExists(string customerId)
        {
            return await context.Customers.AnyAsync(c => c.Id == customerId);
        }
    }
}
