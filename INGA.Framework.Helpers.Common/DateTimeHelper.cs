using System;

namespace INGA.Framework.Helpers.Common
{
    public static class DateTimeHelper
    {
        public static DateTimeOffset ToDateTimeOffset(DateTime dateTime)
        {
            return dateTime.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                       ? DateTimeOffset.MinValue
                       : new DateTimeOffset(dateTime);
        }
    }

}
