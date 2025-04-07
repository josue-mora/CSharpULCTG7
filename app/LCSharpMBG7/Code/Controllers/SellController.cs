using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.DB.Dummies;

namespace LCSharpMBG7.Code.Controllers
{
    public class SellController
    {
        public static void LoadDummySells()
        {
            List<SellModel> sellModels = SellDummies.CreateSells();
            State.sells = sellModels;
        }
    }
}
