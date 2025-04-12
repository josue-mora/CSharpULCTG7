using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class SellDummies
    {
        public static List<SellModel> CreateSells()
        {
            //return new List<SellModel>();
            List<SellModel> sellModels = new List<SellModel>();

            // If there is no vehicles, a placeholder ID is generated.
            // If there are cars, it is related to the first.
            string sold_car_id = DateFormatter.GetUNIXTimestamp().ToString();
            if (State.vehicles != null && State.vehicles.Count > 0)
            {
                sold_car_id = State.vehicles.First().Id;
            }

            sellModels.Add(new SellModel(
                sold_car_id,
                DateFormatter.GetUNIXTimestamp().ToString(),
                "122223333",
                "John Doe"
            ));
            return sellModels;
        }
    }
}
