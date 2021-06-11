using CoinService.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinService.Controllers
{
	public class CoinsController : BaseController
	{
		private IConfiguration _configuration;
		public CoinsController(ILogger<AuthController> logger, IConfiguration configuration) : base(logger)
		{
			_configuration = configuration;
		}

		
		[HttpGet("get")]
		public async Task<IActionResult> GetCommend()
		{
			bool status;
			try
			{
				var client = new RestClient("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?CMC_PRO_API_KEY=148cfa5d-2cb5-4eaf-aeb1-11e0dfe00c49");
				client.Timeout = -1;
				var request = new RestRequest(Method.GET);
				IRestResponse response = client.Execute(request);
				status = true;
				return Ok(new {data= response.Content, status=status });



			}
			catch (Exception e)
			{
				status = false;
				_logger.LogError("Veri getirilirken bir hata oluştu. " + DateTime.Now.ToString());
				return BadRequest();
			}

		}

	}
}
