namespace LCSharpMBG7.Code.Logical
{
    public class DateFormatter
    {
        public static long GetUNIXTimestamp()
        {
            DateTimeOffset dto = DateTimeOffset.UtcNow;
            long unixTime = dto.ToUnixTimeMilliseconds();
            return long.Parse(unixTime.ToString());
        }

        public static string FormatUNIXToDate(string unix_time)
        {
            try
            {
                DateTimeOffset date = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(unix_time));
                return date.ToString("dd-MM-yyyy");
            }
            catch (Exception)
            {
                return "01-01-1911";
            }
        }
    }
}
