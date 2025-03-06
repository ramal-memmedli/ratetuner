using RateTuner.Monitoring.Shared;
using RateTuner.Monitoring.Shared.Enums;
using RateTuner.Monitoring.Shared.Exceptions;

namespace RateTuner.Monitor.Tests.Shared;

public class MonitorDelayUnitTests
{
    #region CheckAndApplyRules

    [Fact]
    public void CheckAndApplyRules_ShouldThrowInvalidDelayTypeException_WhenDelayTypeIsInvalid()
    {
        // Arrange

        TimeUnit type = (TimeUnit)100;
        int interval = 1000;

        // Act
        Action action = () => new Interval(type, interval);

        // Assert
        Assert.Throws<InvalidTimeUnitException>(action);
    }

    [Theory]
    // Range for Milliseconds is 1 to 999
    [InlineData(TimeUnit.Milliseconds, -808080)]
    [InlineData(TimeUnit.Milliseconds, -1)]
    [InlineData(TimeUnit.Milliseconds, 0)]
    [InlineData(TimeUnit.Milliseconds ,1000)]
    [InlineData(TimeUnit.Milliseconds, 808080)]
    // Range for Seconds is 1 to 59
    [InlineData(TimeUnit.Seconds, -808080)]
    [InlineData(TimeUnit.Seconds, -1)]
    [InlineData(TimeUnit.Seconds, 0)]
    [InlineData(TimeUnit.Seconds, 60)]
    [InlineData(TimeUnit.Seconds, 808080)]
    // Range for Minutes is 1 to 59
    [InlineData(TimeUnit.Minutes, -808080)]
    [InlineData(TimeUnit.Minutes, -1)]
    [InlineData(TimeUnit.Minutes, 0)]
    [InlineData(TimeUnit.Minutes, 60)]
    [InlineData(TimeUnit.Minutes, 808080)]
    // Range for Hours is 1 to 24
    [InlineData(TimeUnit.Hours, -808080)]
    [InlineData(TimeUnit.Hours, -1)]
    [InlineData(TimeUnit.Hours, 0)]
    [InlineData(TimeUnit.Hours, 25)]
    [InlineData(TimeUnit.Hours, 808080)]
    public void CheckAndApplyRules_ShouldThrowDelayIntervalOutOfRangeException_WhenDelayIntervalIsOutOfExpectedRanges(TimeUnit type, int interval)
    {
        // Act

        Action action = () => new Interval(type, interval);

        // Assert
        Assert.Throws<IntervalDurationOutOfRangeException>(action);
    }

    [Theory]
    // Range for Milliseconds is 1 to 999
    [InlineData(TimeUnit.Milliseconds, 1)]
    [InlineData(TimeUnit.Milliseconds, 500)]
    [InlineData(TimeUnit.Milliseconds, 999)]
    // Range for Seconds is 1 to 59
    [InlineData(TimeUnit.Seconds, 1)]
    [InlineData(TimeUnit.Seconds, 30)]
    [InlineData(TimeUnit.Seconds, 59)]
    // Range for Minutes is 1 to 59
    [InlineData(TimeUnit.Minutes, 1)]
    [InlineData(TimeUnit.Minutes, 30)]
    [InlineData(TimeUnit.Minutes, 59)]
    // Range for Hours is 1 to 24
    [InlineData(TimeUnit.Hours, 1)]
    [InlineData(TimeUnit.Hours, 12)]
    [InlineData(TimeUnit.Hours, 24)]
    public void CheckAndApplyRules_ShouldCreateInstance_WhenDelayIntervalIsInExpectedRangesAndDelayTypeIsValid(TimeUnit type, int interval)
    {
        // Act
        Interval monitorDelay = new Interval(type, interval);
        Exception exception = Record.Exception(() => new Interval(type, interval));

        // Assert
        Assert.Null(exception);
        Assert.NotNull(monitorDelay);
        Assert.IsType<Interval>(monitorDelay);
    }

    #endregion
}
