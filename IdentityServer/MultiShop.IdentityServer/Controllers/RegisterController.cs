using Duende.IdentityServer;
using Duende.IdentityServer.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controllers
{
	[Authorize(IdentityServerConstants.LocalApi.PolicyName)]
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public RegisterController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var values = new ApplicationUser()
			{
				UserName = userRegisterDto.Username,
				Email = userRegisterDto.Email,
				Name = userRegisterDto.Name,
				Surname = userRegisterDto.Surname,
			};
			var result = await _userManager.CreateAsync(values,userRegisterDto.Password);
			if(result.Succeeded )
			{
				return Ok("User added successfully ! ");
			}
			else
			{
				return Ok("Something went wrong ! ");
			}
		}
	}
}
