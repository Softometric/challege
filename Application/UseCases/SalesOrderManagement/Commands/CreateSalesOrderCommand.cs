
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Common.Models.SalesOrderDto;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.SalesOrderManagement.Commands
{
    public class CreateSalesOrderCommand : SalesOrderRequestModel, IRequest<ResponseModel>
    {

    }

    public class CreateSalesOrderCommandHandler : IRequestHandler<CreateSalesOrderCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public CreateSalesOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(CreateSalesOrderCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.SalesOrderStore.ProductExists(request.ProductId!))
                return ResponseModel.Failure("Product does not exist");

            if (!await _uow.SalesOrderStore.CustomerExists(request.CustomerId!))
                return ResponseModel.Failure("Customer does not exist");


            _uow.SalesOrderStore.Insert(new SalesOrder
            {
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Status = request.Status,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                Created = DateTime.Now,
                Discount = request.Discount,
                Done = true
                
                
            });
            await _uow.Commit();
            return ResponseModel.Success("You have successfully created new sales order");

        }
    }
}
