using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class SellDummies
    {
        public static List<SellModel> CreateSells()
        {
            var sellModels = new List<SellModel>();
            Random random = new Random();

            string[] fakeNames = new string[]
            {
                "John Doe", "Jane Smith", "Alice Johnson", "Bob Brown",
                "Charlie Davis", "Diana Evans", "Frank Green", "Grace Harris",
                "Henry Jackson", "Ivy King"
            };

            for (int i = 0; i < 60; i++)
            {
                string sold_car_id = State.vehicles[i % State.vehicles.Count].Id;
                string sellDate = DateFormatter.GetUNIXTimestamp().ToString();

                // Generate a fake user ID card number with some variation
                // Example: "122223333" + i padded to 3 digits
                string userIdCard = "12222" + (300 + i).ToString("D4"); // 122223003, 122223004, D4 = Decimal 4 digits.

                string userName = fakeNames[i % fakeNames.Length];

                SellModel sell = new SellModel(sold_car_id, sellDate, userIdCard, userName);
                sellModels.Add(sell);
            }

            return sellModels;
        }
    }
}
