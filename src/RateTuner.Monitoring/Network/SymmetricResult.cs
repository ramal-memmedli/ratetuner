using RateTuner.Monitoring.Shared;

namespace RateTuner.Monitoring.Network
{
    public class SymmetricResult : IMonitoringResult
    {
        public long UploadSpeed { get; }
        public long DownloadSpeed { get; }

        public SymmetricResult(long uploadSpeed, long downloadSpeed)
        {
            UploadSpeed = uploadSpeed;
            DownloadSpeed = downloadSpeed;
        }
    }
}
