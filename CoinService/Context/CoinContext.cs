using CoinService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinService.Context
{
	public class CoinContext: DbContext
	{
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@$"Data Source = {AppContext.BaseDirectory}\CoinDatabase.db");
		}

        public DbSet<User> Users { get; set; }

    }
}
