namespace PuroVoteSystem.Mvc.Utils
{
    public class JobCommon : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                
                await new TaskFactory().StartNew(() =>
                {
                    Console.WriteLine(DateTime.Now);
                });
                Thread.Sleep(1000);
            }
            throw new NotImplementedException();
        }
    }
}
