
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.CustomerManagement.Commands
{
    public class DeleteCustomerCommand : IRequest<ResponseModel>
    {
        public string? CustomerId { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if ( _uow.CustomerStore.GetFirstOrDefault(x=>x.Id == request.CustomerId) is not { })
                return ResponseModel.Failure("Inventory not found");

            _uow.CustomerStore.Delete(request.CustomerId!);
            await _uow.Commit();
            return ResponseModel.Success("Successfully deleted a customer...");

        }
    }
}
