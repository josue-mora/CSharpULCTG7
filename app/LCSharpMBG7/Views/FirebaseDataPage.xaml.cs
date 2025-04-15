using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Views
{
    public partial class FirebaseDataPage : ContentPage
    {
        public FirebaseDataPage()
        {
            InitializeComponent();
        }

        // When the page appears, load data from Firebase for all models.
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set state elements into local GUI context.
            VehiclesCollectionView.ItemsSource = State.vehicles;
            ReservationsCollectionView.ItemsSource = State.reservations;
            SellsCollectionView.ItemsSource = State.sells;
            UsersCollectionView.ItemsSource = State.users;
        }
    }
}
