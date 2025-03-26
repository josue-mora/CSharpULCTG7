using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.Controllers
{
    public class UserController
    {
        public void LoadDummyUsers()
        {
            List<UserModel> userModels = UserDBDummies.CreateUsers();
            State.users = userModels;
        }
    }
}
