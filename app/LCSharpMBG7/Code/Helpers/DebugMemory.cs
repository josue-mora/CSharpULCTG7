using LCSharpMBG7.Code.Logical;
using System.Diagnostics;

namespace LCSharpMBG7.Code.Helpers
{
    public class DebugMemory
    {
        public static void Data()
        {
            Debug.WriteLine("Dummy Vehicles:");
            if (State.vehicles != null)
            {
                foreach (var vehicle in State.vehicles)
                    Debug.WriteLine(vehicle.ToString());
            }

            Debug.WriteLine("Dummy Users:");
            if (State.users != null)
            {
                foreach (var user in State.users)
                    Debug.WriteLine(user.ToString());
            }

            Debug.WriteLine("Dummy Sells:");
            if (State.sells != null)
            {
                foreach (var sell in State.sells)
                    Debug.WriteLine(sell.ToString());
            }

            Debug.WriteLine("Dummy Reservations:");
            if (State.reservations != null)
            {
                foreach (var res in State.reservations)
                    Debug.WriteLine(res.ToString());
            }

            Debug.WriteLine("Dummy Invoices:");
            if (State.invoices != null)
            {
                foreach (var res in State.invoices)
                    Debug.WriteLine(res.ToString());
            }

            // Testing date formatter.
            string unixDate = DateFormatter.GetUNIXTimestamp().ToString();
            Debug.WriteLine("Unix Date: " + unixDate);
            Debug.WriteLine("Formatted Date: " + DateFormatter.FormatUNIXToDate(unixDate));
        }
    }
}
