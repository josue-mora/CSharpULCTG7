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
    }
}
