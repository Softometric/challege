﻿using Application.Common.Extensions;
using Application.Common.Models;
using Application.Common.Models.ProductDto;
using Application.UseCases.ProductManagement.Commands;
using Application.UseCases.ProductManagement.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    public class ProductController : ApiControllerBase
    {
        [HttpPost]
        [Route("Create-Product")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
        [HttpGet]
        [Route("Get-Products")]
        [ProducesResponseType(typeof(ResponseModel<ProductModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProductsQuery{});
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete]
        [Route("Delete-Product/{productId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct([FromRoute] string productId)
        {
            var command = new DeleteProductCommand
            {
                ProductId = productId
            };
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}
