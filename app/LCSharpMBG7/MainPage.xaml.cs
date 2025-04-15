﻿using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Views;

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

            // --------------------------------------------------------
            // Testing output of dummy created reservations.
            ReservationController.LoadDummyReservations();
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");
            foreach (var res in State.reservations)
            {
                System.Diagnostics.Debug.WriteLine(res.ToString());
            }
            System.Diagnostics.Debug.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeee");

            InitializeComponent();
        }

        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MainPageMenu");
        }

        private async void LogInAdmin(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("LogInAdmin");
        }


    }
}
