﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
		private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

		public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
		{
			_getOrderDetailQueryHandler = getOrderDetailQueryHandler;
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var values = await _getOrderDetailQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderDetailById(int id)
		{
			var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok("Order detail added successfully ! ");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveOrderDetail(int id)
		{
			await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
			return Ok("Order detail deleted successfully !");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok("Order detail updated !");
		}

	}
}