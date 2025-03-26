using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.Helpers
{
    public class UserHelper
    {
        public static UserModel CreateAdministratorHighest
        (
            string name,
            string email,
            string password
        )
        {
            UserModel userModel = new UserModel();
            userModel
                .SetName(name)
                .SetEmail(email)
                .SetPassword(password)
                .SetRole(Constants.USER_ROLES[Constants.USER_ROLES.Length - 1]);
            return userModel;
        }
    }
}
