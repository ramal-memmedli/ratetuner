using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateTuner.Monitoring.Shared.Exceptions
{
    public class TransferRateOutOfRangeException : Exception
    {
        public TransferRateOutOfRangeException(string message): base(message)
        {
            
        }
    }
}
