using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Views
{
    public partial class FirebaseDataPage : ContentPage
    {
        public FirebaseDataPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            VehiclesCollectionView.ItemsSource = State.vehicles;
            ReservationsCollectionView.ItemsSource = State.reservations;
            SellsCollectionView.ItemsSource = State.sells;
            UsersCollectionView.ItemsSource = State.users;
        }
    }
}
