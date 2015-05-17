using System;
using System.Collections.Generic;

namespace INGA.Framework.Managers.Common
{
    public class ResultDocument<T>
    {
        public T Result { get; set; }
        public IEnumerable<T> Results { get; set; }
        public ResultStatus Status { get; set; }
        public ResultOperation OperationType { get; set; }
        public Type Type { get; set; }
        public double Duration
        {
            get
            {
                return Math.Abs(EndDatime.Subtract(StartTime).TotalSeconds);
            }
        }

        public DateTime StartTime { get; set; }
        public DateTime EndDatime { get; set; }

        public Exception Exception { get; set; }

        public Dictionary<string, object> ExtraField { get; set; } 
    }
}
