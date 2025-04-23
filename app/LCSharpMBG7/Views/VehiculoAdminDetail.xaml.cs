using Firebase.Database.Query;
using Firebase.Storage;                 
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;
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

            if (!string.IsNullOrEmpty(VehicleId))
            {
                var items = await FirebaseHelper
                    .CreateConnection()
                    .Child("Vehicles")
                    .OnceAsync<VehicleModel>();

                var entry = items.FirstOrDefault(x => x.Object.Id == VehicleId);
                if (entry != null)
                {
                    _firebaseKey = entry.Key;
                    var v = entry.Object;

                    modelEntry.Text          = v.Model;
                    nameEntry.Text           = v.Name;
                    yearEntry.Text           = v.Year.ToString();
                    priceEntry.Text          = v.Price.ToString();
                    stateEntry.Text          = v.State;
                    pageContentEditor.Text   = v.PageContent;
                    imageCarouselEntry.Text  = v.ImageCarousel;
                    promotedSwitch.IsToggled = v.Promoted;

                    deleteButton.IsVisible   = true;
                }
            }
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
                promotedSwitch.IsToggled);

            var fb = FirebaseHelper.CreateConnection();
            if (string.IsNullOrEmpty(_firebaseKey))
                await fb.Child("Vehicles").PostAsync(vehicle);
            else
                await fb.Child("Vehicles").Child(_firebaseKey!).PutAsync(vehicle);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_firebaseKey)) return;

            await FirebaseHelper
                .CreateConnection()
                .Child("Vehicles")
                .Child(_firebaseKey)
                .DeleteAsync();

            await Shell.Current.GoToAsync("..");
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
                var ext      = Path.GetExtension(photo.FileName);
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
