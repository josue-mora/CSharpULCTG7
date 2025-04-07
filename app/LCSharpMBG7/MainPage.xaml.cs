using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            // --------------------------------------------------------
            // Testing output of dummy created vehicles.
            VehicleController controller = new VehicleController();
            controller.LoadDummyVehicles();
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");
            foreach (var vehicle in State.vehicles)
            {
                System.Diagnostics.Debug.WriteLine(vehicle.ToString());
            }
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");

            // --------------------------------------------------------
            // Testing output of dummy created users.
            UserController userController = new UserController();
            userController.LoadDummyUsers();
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");
            foreach (var user in State.users)
            {
                System.Diagnostics.Debug.WriteLine(user.ToString());
            }
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");

            // --------------------------------------------------------
            // Testing output of dummy created sells.
            SellController.LoadDummySells();
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");
            foreach (var sell in State.sells)
            {
                System.Diagnostics.Debug.WriteLine(sell.ToString());
            }
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");

            // --------------------------------------------------------
            // Testing on date formatter.
            string unix_date = "" + DateFormatter.GetUNIXTimestamp();
            System.Diagnostics.Debug.WriteLine(unix_date);
            System.Diagnostics.Debug.WriteLine(DateFormatter.FormatUNIXToDate(unix_date));

            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
