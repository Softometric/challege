
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.ProductManagement.Commands
{
    public class DeleteProductCommand : IRequest<ResponseModel>
    {
        public string? ProductId { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;


        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _uow = unitOfWork;
            _configuration = configuration;
           
        }

        public async Task<ResponseModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if ( _uow.ProductStore.GetFirstOrDefault(x=>x.Id == request.ProductId) is not { })
                return ResponseModel.Failure("Product not found");

            _uow.ProductStore.Delete(request.ProductId!);

            await _uow.Commit();
            return ResponseModel.Success("Successfully deleted a product...");


        }
    }
}
