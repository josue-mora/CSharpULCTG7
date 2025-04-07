using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class SellDummies
    {
        public static List<SellModel> CreateSells()
        {
            List<SellModel> sellModels = new List<SellModel>();

            string sold_car_id = DateFormatter.GetUNIXTimestamp() + "";
            if (State.vehicles != null && State.vehicles.Count > 0)
            {
                sold_car_id = State.vehicles[0].GetId();
            }

            sellModels.Add(new SellModel(sold_car_id, DateFormatter.GetUNIXTimestamp() + "", "1-2222-3333", "John Doe"));
            return sellModels;
        }
    }
}
