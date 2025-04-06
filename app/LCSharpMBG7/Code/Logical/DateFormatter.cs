using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSharpMBG7.Code.Logical
{
    public class DateFormatter
    {
        public static int GetUNIXTimestamp()
        {
            DateTimeOffset dto = DateTimeOffset.UtcNow;
            long unixTime = dto.ToUnixTimeSeconds();
            return int.Parse(unixTime.ToString());
        }
    }
}
