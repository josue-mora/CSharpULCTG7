using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class ReservationDummies
    {
        public static List<ReservationModel> CreateReservations()
        {
            List<ReservationModel> models = new List<ReservationModel>();

            string sold_car_id = DateFormatter.GetUNIXTimestamp() + "";
            if (State.vehicles != null && State.vehicles.Count > 0)
            {
                sold_car_id = State.vehicles[0].GetId();
            }

            models.Add(new ReservationModel(sold_car_id, DateFormatter.GetUNIXTimestamp() + "", DateFormatter.GetUNIXTimestamp() + "", "12223333", "John Doe", "Color blanco."));

            return models;
        }
    }
}
