﻿
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.InventoryManagement.Commands
{
    public class DeleteInventoryCommand : IRequest<ResponseModel>
    {
        public string? InventoryId { get; set; }
    }

    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public DeleteInventoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            if ( _uow.InventoryStore.GetFirstOrDefault(x=>x.Id == request.InventoryId) is not { })
                return ResponseModel.Failure("Inventory not found");

            _uow.InventoryStore.Delete(request.InventoryId!);
            await _uow.Commit();
            return ResponseModel.Success("Successfully deleted an inventory...");

        }
    }
}
