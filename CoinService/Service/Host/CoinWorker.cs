using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoinService.Service.Host
{
	public class CoinWorker: IWorker
	{
        private readonly ILogger<CoinWorker> logger;
        private int number = 0;
        private Timer timer;
        public CoinWorker(ILogger<CoinWorker> logger)
        {

            this.logger = logger;
            this.timer = new Timer(o => UpdateData(), null, TimeSpan.Zero, TimeSpan.FromDays(1)); //TimeSpan.FromHours(1)

        }

        public async Task UpdateData()
        {
            Interlocked.Increment(ref number);
            logger.LogInformation($"{number} - Background Worker is running : {DateTime.Now}");
            /*
             * Update Data Cde Block in here
             */
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested) ;
        }
    }
}
