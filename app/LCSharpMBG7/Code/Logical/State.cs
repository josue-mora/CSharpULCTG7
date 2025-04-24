using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.Logical
{
    public class State
    {
        // 0 = Dummies
        // 1 = Firebase
        // 2 = Dummies and Firebase
        public readonly static int DATA_SOURCE = 0;
        public static List<VehicleModel> vehicles;
        public static List<UserModel> users;
        public static List<SellModel> sells;
        public static List<ReservationModel> reservations;
        // Admin sesion user id. Null means no session active.
        public static UserModel AdminUserSession = null;
        // Selected vehicle for review. Stores index in List.
        public static int SelectedVehicleIndex = 0;
        public static bool DevMode = false;
        public static string OnAdminAction = "";
    }
}
