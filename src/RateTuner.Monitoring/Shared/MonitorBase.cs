using RateTuner.Monitoring.Shared.Enums;

namespace RateTuner.Monitoring.Shared
{
    public abstract class MonitorBase
    {
        protected CancellationTokenSource? _cancellationTokenSource;

        protected Interval _interval = new Interval(TimeUnit.Seconds, 1);
        
        public event Action<IMonitoringResult>? OnNetworkUsageMeasured;
        public void Start()
        {
            if (IsMonitorRunning())
            {
                Console.WriteLine("Monitoring is already running.");
                return;
            }
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => RunMonitoringAsync(_cancellationTokenSource.Token));
        }
        protected abstract Task RunMonitoringAsync(CancellationToken token);
        public bool IsMonitorRunning()
        {
            return _cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested;
        }
        public void StopMonitor()
        {
            if (!IsMonitorRunning())
            {
                Console.WriteLine("Monitoring is not running.");
            }

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}
