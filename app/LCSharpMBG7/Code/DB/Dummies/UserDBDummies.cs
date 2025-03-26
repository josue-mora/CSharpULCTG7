using LCSharpMBG7.Code.Helpers;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class UserDBDummies
    {
        public static List<UserModel> CreateUsers()
        {
            List<UserModel> userModels = new List<UserModel>();
            userModels.Add(UserHelper.CreateAdministratorHighest("admin", "admin@mail.com", "admin"));
            return userModels;
        }
    }
}

