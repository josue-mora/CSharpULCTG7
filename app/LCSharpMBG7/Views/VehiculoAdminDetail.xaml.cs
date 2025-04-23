using Firebase.Storage;
using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;
using MP = Microsoft.Maui.Media.MediaPicker;
using MPOptions = Microsoft.Maui.Media.MediaPickerOptions;

namespace LCSharpMBG7.Views
{
    [QueryProperty(nameof(VehicleId), "vehicleId")]
    public partial class VehiculoAdminDetail : ContentPage
    {
        private string? _firebaseKey;
        public string? VehicleId { get; set; }

        public VehiculoAdminDetail()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            VehicleModel vehicle = new VehicleModel();

            if (State.OnAdminAction == "edit_vehicle")
            {
                vehicle = State.vehicles[State.SelectedVehicleIndex];
            }

            modelEntry.Text = vehicle.Model;
            nameEntry.Text = vehicle.Name;
            yearEntry.Text = vehicle.Year.ToString();
            priceEntry.Text = vehicle.Price.ToString();
            stateEntry.Text = vehicle.State;
            pageContentEditor.Text = vehicle.PageContent;
            imageCarouselEntry.Text = vehicle.ImageCarousel;
            promotedSwitch.IsToggled = vehicle.Promoted;
            activeSwitch.IsToggled = vehicle.Active;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            int.TryParse(yearEntry.Text, out var year);
            int.TryParse(priceEntry.Text, out var price);

            var vehicle = new VehicleModel(
                modelEntry.Text!,
                nameEntry.Text!,
                year,
                price,
                stateEntry.Text!,
                pageContentEditor.Text!,
                imageCarouselEntry.Text!,
                promotedSwitch.IsToggled
                );
            vehicle.Active = activeSwitch.IsToggled;

            if (State.OnAdminAction == "create_vehicle")
            {
                await VehicleController.AddVehicleAsync(vehicle);
                await DisplayAlert("Hecho", "Se ha guardado el vehículo.", "OK");
            }
            else
            {
                // Edit.
                vehicle.Id = State.vehicles[State.SelectedVehicleIndex].Id;
                await VehicleController.UpdateVehicleAsync(State.vehicles[State.SelectedVehicleIndex].Id, vehicle);
                await DisplayAlert("Hecho", "El vehículo ha sido editado.", "OK");
            }

        }

        private async void OnPickAndUploadImageClicked(object sender, EventArgs e)
        {
            try
            {
                // 1) Pick a photo with the MAUI API
                var photo = await MP.PickPhotoAsync(new MPOptions
                {
                    Title = "Selecciona una imagen"
                });
                if (photo == null)
                    return;

                // 2) Open read stream
                using var stream = await photo.OpenReadAsync();

                // 3) Unique filename
                var ext = Path.GetExtension(photo.FileName);
                var filename = $"{Guid.NewGuid()}{ext}";

                // 4) Instantiate the .NET storage client
                var storage = new FirebaseStorage("mercedesshowroom-679f7.firebasestorage.app");

                // 5) Upload and get download URL
                string downloadUrl = await storage
                    .Child("vehicleImages")
                    .Child(filename)
                    .PutAsync(stream);

                // 6) Save their URL
                imageCarouselEntry.Text = downloadUrl;
                await DisplayAlert("Éxito", "Imagen subida correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
