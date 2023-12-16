using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Common.Models.CustomerDto;
using Application.Common.Models.SalesOrderDto;
using MediatR;

namespace Application.UseCases.SalesOrderManagement.Queries
{
    public class GetSalesOrdersQuery : IRequest<ResponseModel>
    {
    }
    public class GetSalesOrdersQueryHandler : IRequestHandler<GetSalesOrdersQuery, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public GetSalesOrdersQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
           
        }
        public async Task<ResponseModel> Handle(GetSalesOrdersQuery request, CancellationToken cancellationToken)
        {
            if (_uow.SalesOrderStore.Get() is not { } salesOrders)
            {
                return ResponseModel<List<SalesOrderResponseModel>>.Success(data: new List<SalesOrderResponseModel>(), "Sales order list is empty");
            }

            return ResponseModel<List<SalesOrderResponseModel>>.Success(data: salesOrders.Select(c => new SalesOrderResponseModel
            {
                Id = c.Id,
                CustomerId = c.CustomerId,
                ProductId = c.ProductId,
                Discount = c.Discount,
                Quantity = c.Quantity,
                Status = c.Status.ToString(),
                UnitPrice = c.UnitPrice
            }).ToList());
        }
    }
}
