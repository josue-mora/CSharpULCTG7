namespace LCSharpMBG7.Code.Validators
{
    public class UnixTimeValidator
    {
        public static bool IsValidUnixTimeMilliseconds(string unixTimeString)
        {
            if (string.IsNullOrEmpty(unixTimeString)) return false;

            foreach (char c in unixTimeString)
            {
                if (!char.IsDigit(c)) return false;
            }

            if (!long.TryParse(unixTimeString, out long unixTimeMs)) return false;

            const long MinUnixTimeMs = 0; // 1970-01-01T00:00:00Z
            const long MaxUnixTimeMs = 32503680000000; // Year 3000-01-01T00:00:00Z

            if (unixTimeMs < MinUnixTimeMs || unixTimeMs > MaxUnixTimeMs) return false;

            // Valid Unix time.
            return true;
        }
    }
}
