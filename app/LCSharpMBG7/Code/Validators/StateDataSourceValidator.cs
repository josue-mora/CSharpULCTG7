using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Validators
{
    public class StateDataSourceValidator
    {
        public static void Validate()
        {
            if (State.DATA_SOURCE == 2)
            {
                throw new ArgumentException("Configuration for Dummies + Firebase combined not implemented yet.");
            }
            else if (State.DATA_SOURCE > 2 || State.DATA_SOURCE < 0)
            {
                throw new ArgumentException("Invalid data load configuration.");
            }
        }
    }
}
