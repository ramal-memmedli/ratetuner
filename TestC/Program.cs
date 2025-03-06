using System.Diagnostics;
using System.Net.NetworkInformation;

public class Program
{
    private static void Main(string[] args)
    {
        PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        Console.WriteLine(counter.NextValue());

        Console.ReadLine();
    }
}