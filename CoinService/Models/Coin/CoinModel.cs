using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinService.Models.Coin
{
	public class CoinModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public string symbol { get; set; }
		public string slug { get; set; }
		public int num_market_pairs { get; set; }
		public DateTime date_added { get; set; }
	}
}
