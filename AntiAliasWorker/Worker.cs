using AntiAliasWorker.Logic;

namespace AntiAliasWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private string from = "E:\\Files";
        private string to = "E:\\Files\\results";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string[] fileEntries = Directory.GetFiles(from);
            int index = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                if ((fileEntries.Length - 1) < index)
                    break;

                Iteration(fileEntries[index++]);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void Iteration(string file)
        {
            var fi = new FileInfo(file);

            ImageSearching.Conturs(file, $"{to}/{fi.Name}");
        }
    }
}