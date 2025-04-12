using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class ReservationDummies
    {
        public static List<ReservationModel> CreateReservations()
        {
            //return new List<ReservationModel>();
            List<ReservationModel> models = new List<ReservationModel>();

            // If there is no vehicles, a placeholder ID is generated.
            // If there are cars, it is related to the first.
            string sold_car_id = DateFormatter.GetUNIXTimestamp().ToString();
            if (State.vehicles != null && State.vehicles.Count > 0)
            {
                sold_car_id = State.vehicles.First().Id;
            }

            models.Add(new ReservationModel(
                sold_car_id,
                DateFormatter.GetUNIXTimestamp().ToString(),
                DateFormatter.GetUNIXTimestamp().ToString(),
                "12223333",
                "John Doe",
                "Color blanco."
            ));

            return models;
        }
    }
}
