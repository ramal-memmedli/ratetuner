using RateTuner.Monitoring.Shared;
using RateTuner.Monitoring.Shared.Extensions;
using System.Diagnostics;

namespace RateTuner.Monitoring.CPU;

public class CPUMonitor : MonitorBase
{
    protected override Task RunMonitoringAsync(CancellationToken token)
    {
        if (SharedExtensions.IsWindows())
        {
            WindowsCpuUsage();
        }
        else if (SharedExtensions.IsLinux()) { }
        else if (SharedExtensions.IsMacOS()) { }
        else
        {
        }

        return Task.CompletedTask;
    }

    public void WindowsCpuUsage()
    {
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        cpuCounter.NextValue();
        Thread.Sleep(1000);
        Console.WriteLine($"CPU Usage: {cpuCounter.NextValue()}%");
    }
}
