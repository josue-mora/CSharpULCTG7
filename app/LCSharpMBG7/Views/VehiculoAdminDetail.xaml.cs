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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vehicle = new VehicleModel();
            deleteButton.IsVisible = false;

            if (State.OnAdminAction == "edit_vehicle" && VehicleId != null)
            {
                vehicle      = State.vehicles[State.SelectedVehicleIndex];
                _firebaseKey = vehicle.Id;
                deleteButton.IsVisible = true;
            }

            modelEntry.Text          = vehicle.Model;
            nameEntry.Text           = vehicle.Name;
            yearEntry.Text           = vehicle.Year.ToString();
            priceEntry.Text          = vehicle.Price.ToString();
            stateEntry.Text          = vehicle.State;
            pageContentEditor.Text   = vehicle.PageContent;
            imageCarouselEntry.Text  = vehicle.ImageCarousel;
            promotedSwitch.IsToggled = vehicle.Promoted;
            activeSwitch.IsToggled   = vehicle.Active;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            int.TryParse(yearEntry.Text,  out var year);
            int.TryParse(priceEntry.Text, out var price);

            var vehicle = new VehicleModel(
                modelEntry.Text!,
                nameEntry.Text!,
                year,
                price,
                stateEntry.Text!,
                pageContentEditor.Text!,
                imageCarouselEntry.Text!,
                promotedSwitch.IsToggled)
            {
                Active = activeSwitch.IsToggled
            };

            if (State.OnAdminAction == "create_vehicle")
            {
                await VehicleController.AddVehicleAsync(vehicle);
                await DisplayAlert("Hecho", "Vehículo creado correctamente.", "OK");
            }
            else
            {
                vehicle.Id = _firebaseKey!;
                await VehicleController.UpdateVehicleAsync(_firebaseKey!, vehicle);
                await DisplayAlert("Hecho", "Vehículo actualizado correctamente.", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_firebaseKey == null) return;
            if (!await DisplayAlert("Confirmar", "¿Eliminar vehículo?", "Sí", "No")) return;

            await VehicleController.DeleteVehicleAsync(_firebaseKey);
            await DisplayAlert("Hecho", "Vehículo eliminado correctamente.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        private async void OnPickAndUploadImageClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MP.PickPhotoAsync(new MPOptions { Title = "Selecciona una imagen" });
                if (photo == null) return;

                using var stream = await photo.OpenReadAsync();
                var ext      = System.IO.Path.GetExtension(photo.FileName);
                var filename = $"{Guid.NewGuid()}{ext}";

                var storage = new FirebaseStorage("mercedesshowroom-679f7.firebasestorage.app");
                string downloadUrl = await storage
                    .Child("vehicleImages")
                    .Child(filename)
                    .PutAsync(stream);

                imageCarouselEntry.Text = downloadUrl;
                await DisplayAlert("Éxito", "Imagen subida correctamente.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
