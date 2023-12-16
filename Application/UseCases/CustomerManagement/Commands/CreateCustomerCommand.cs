
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Common.Models.CustomerDto;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.CustomerManagement.Commands
{
    public class CreateCustomerCommand : CustomerRequestModel, IRequest<ResponseModel>
    {

    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.CustomerStore.EmailExists(request.Email!))
                return ResponseModel.Failure("Email Address exist");


            _uow.CustomerStore.Insert(new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CustomerAddress = new Address(request.StreetNumber, request.StreetName, request.LandMark, request.City),
                Gender = request.Gender,
                Created = DateTime.Now,
                PhoneNo = request.PhoneNo,
                Done = true
                
                
            });
            await _uow.Commit();
            return ResponseModel.Success("You have successfully created new customer");

        }
    }
}
