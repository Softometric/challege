
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.SalesOrderManagement.Commands
{
    public class DeleteSalesOrderCommand : IRequest<ResponseModel>
    {
        public string? OrderId { get; set; }
    }

    public class DeleteSalesOrderCommandHandler : IRequestHandler<DeleteSalesOrderCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public DeleteSalesOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(DeleteSalesOrderCommand request, CancellationToken cancellationToken)
        {
            if ( _uow.SalesOrderStore.GetFirstOrDefault(x=>x.Id == request.OrderId) is not { })
                return ResponseModel.Failure("Sales order not found");

            _uow.SalesOrderStore.Delete(request.OrderId!);
            await _uow.Commit();
            return ResponseModel.Success("Successfully deleted a sales order...");

        }
    }
}
