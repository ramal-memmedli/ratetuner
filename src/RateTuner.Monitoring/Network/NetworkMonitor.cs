using RateTuner.Monitoring.Shared;
using System.Net.NetworkInformation;

namespace RateTuner.Monitoring.Network;

public sealed class NetworkMonitor : MonitorBase
{
    private readonly NetworkInterface _networkInterface;

    private long _lastUploadRecord;

    public NetworkMonitor(NetworkInterface networkInterface, Interval interval)
    {
        _interval = interval;

        if (networkInterface != null)
        {
            _networkInterface = networkInterface;
        }else
        {
            throw new ArgumentNullException(nameof(networkInterface));
        }

        _lastUploadRecord = GetUploadRecord();
    }

    protected override async Task RunMonitoringAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Monitoring starting...");

        Console.WriteLine($"Monitoring started on {_networkInterface.Name}.");

        while (!cancellationToken.IsCancellationRequested)
        {   
            await Task.Delay(_interval.DurationInMilliseconds, cancellationToken);

            long currentUploadRecord = GetUploadRecord();

            long uploadSpeed = currentUploadRecord - _lastUploadRecord;

            _lastUploadRecord = currentUploadRecord;
        }
    }

    private long GetUploadRecord()
    {
        return _networkInterface.GetIPStatistics().BytesSent;
    }
}
