﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderingsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> OrderingList()
		{
			var response = await _mediator.Send(new GetOrderingQuery());
			return Ok(response);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderingById(int id)
		{
			var response = await _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok(response);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Order Done !");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveOrdering(int id)
		{
			await _mediator.Send(new RemoveOrderingCommand(id));
			return Ok("Order Deleted !");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Order Updated !");
		}
	}
}
