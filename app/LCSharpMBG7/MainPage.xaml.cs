using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            // Testing output of dummy created vehicles.
            VehicleController controller = new VehicleController();
            controller.LoadDummyVehicles();
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");
            foreach (var vehicle in State.vehicles)
            {
                System.Diagnostics.Debug.WriteLine(vehicle.ToString());
            }
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");

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
