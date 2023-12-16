using Application.Common.Models;
using Application.Common.Models.ProductDto;
using Application.Common.Models.SalesOrderDto;
using Application.UseCases.ProductManagement.Commands;
using Application.UseCases.ProductManagement.Queries;
using Application.UseCases.SalesOrderManagement.Commands;
using Application.UseCases.SalesOrderManagement.Queries;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    public class SalesOrderController : ApiControllerBase
    {
        [HttpPost]
        [Route("Create-Sales-Order")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSalesOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
        [HttpGet]
        [Route("Get-Sales-Orders")]
        [ProducesResponseType(typeof(ResponseModel<SalesOrderResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetSalesOrdersQuery{});
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete]
        [Route("Delete-Sales-Order/{orderId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct([FromRoute] string orderId)
        {
            var command = new DeleteSalesOrderCommand
            {
                OrderId = orderId
            };
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}
