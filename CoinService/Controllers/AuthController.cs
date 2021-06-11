using CoinService.Context;
using CoinService.Entities;
using CoinService.Helpers;
using CoinService.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : BaseController
	{
		private IConfiguration _configuration;
		public AuthController(ILogger<AuthController> logger, IConfiguration configuration) : base(logger)
		{
			_configuration = configuration;
		}


		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login(UserLoginModel user)
		{
			bool status;
			try
			{
				using (var context = new CoinContext())
				{

					//context.Users.Add(new User { Username = "Duygu", Password = "1234" });
					//context.Users.Add(new User { Username = "Duygu1", Password = "1234" });
					//context.Users.Add(new User { Username = "Duygu2", Password = "1234" });
					//context.SaveChanges();
					var result = await context.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);
					if (result != null)
					{
						var token= TokenHelper.CreateToken(_configuration);
						status = true;
						return Ok(new { token=token, username=result.Username, status = status });
					}
					else
					{
						status=false;
						_logger.LogInformation("Kullanıcı girişi hatası "+ DateTime.Now.ToString());
						return Ok(new { token = "", username = "", status = status });
					}
				}

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
