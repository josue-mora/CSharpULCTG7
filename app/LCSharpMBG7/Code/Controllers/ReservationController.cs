using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.DB.Dummies;

namespace LCSharpMBG7.Code.Controllers
{
    public class ReservationController
    {
        public static void LoadDummyReservations()
        {
            List<ReservationModel> models = ReservationDummies.CreateReservations();
            State.reservations = models;
        }
    }
}
