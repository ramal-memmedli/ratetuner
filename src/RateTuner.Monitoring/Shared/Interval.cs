using RateTuner.Monitoring.Shared.Enums;
using RateTuner.Monitoring.Shared.Exceptions;

namespace RateTuner.Monitoring.Shared
{
    public class Interval
    {
        private readonly TimeUnit _unit;
        private readonly int _duration;
        private int _durationInMilliseconds = 1;

        public TimeUnit Unit {
            get { return _unit; }
        }

        public int Duration
        {
            get { return _duration; }
        }

        public int DurationInMilliseconds {
            get { return _durationInMilliseconds; }
        }

        public Interval(TimeUnit unit, int duration)
        {
            CheckAndApplyRules(unit, duration);
            _unit = unit;
            _duration = duration;
        }

        private void CheckAndApplyRules(TimeUnit unit, int duration)
        {
            switch (unit)
            {
                case TimeUnit.Milliseconds:
                    if(duration > 0 && duration < 1000)
                    {
                        _durationInMilliseconds = duration;
                        break;
                    }
                    throw new IntervalDurationOutOfRangeException("Please use Seconds for values greater than 1000 Milliseconds.");
                case TimeUnit.Seconds:
                    if(duration > 0 && duration < 60)
                    {
                        _durationInMilliseconds = duration * 1000;
                        break;
                    }
                    throw new IntervalDurationOutOfRangeException("Please use Minutes for values greater than 59 Seconds.");
                case TimeUnit.Minutes:
                    if(duration > 0 && duration < 60)
                    {
                        _durationInMilliseconds = duration * 60000;
                        break;
                    }
                    throw new IntervalDurationOutOfRangeException("Please use Hours for values greater than 59 Minutes.");
                case TimeUnit.Hours:
                    if (duration > 0 && duration < 25)
                    {
                        _durationInMilliseconds = duration * 3600000;
                        break;
                    }
                    throw new IntervalDurationOutOfRangeException("Please use values equal or lower than 25 Hours or greater than 1 Hour.");
                default:
                    throw new InvalidTimeUnitException("Invalid DelayType.");
            }
        }
    }
}
