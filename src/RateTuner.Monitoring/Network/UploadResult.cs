using RateTuner.Monitoring.Shared;

namespace RateTuner.Monitoring.Network
{
    public class UploadResult : IMonitoringResult
    {
        public long CurrentUploadSpeed { get; }

        public UploadResult(long speed)
        {
            CurrentUploadSpeed = speed;
        }
    }
}
