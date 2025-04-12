using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;
using Firebase.Database.Query;

namespace LCSharpMBG7.Code.Controllers
{
    // Controlador que maneja la carga de datos de vehículos
    public class VehicleController
    {
        // Carga vehículos de prueba desde datos ficticios
        public static void LoadDummyVehicles()
        {
            List<VehicleModel> vehicleModels = VehicleDbDummies.CreateVehicles();
            State.vehicles = vehicleModels;
        }

        // Carga vehículos de forma asíncrona desde Firebase
        public async Task LoadVehiclesFromFirebaseAsync()
        {
            var firebaseHelper = new FirebaseHelper();
            try
            {
                // Obtiene la lista de vehículos de Firebase
                List<VehicleModel> vehicles = await GetAllVehiclesAsync();
                State.vehicles = vehicles;
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la carga
                System.Diagnostics.Debug.WriteLine("Error retrieving vehicles from Firebase: " + ex.Message);
            }
        }

        // Método combinado que carga vehículos según la fuente de datos configurada
        public async Task LoadVehiclesAsync()
        {
            // DATA_SOURCE == 0: Carga solo datos ficticios
            if (State.DATA_SOURCE == 0)
            {
                LoadDummyVehicles();
            }
            // DATA_SOURCE == 1: Carga solo desde Firebase
            else if (State.DATA_SOURCE == 1)
            {
                await LoadVehiclesFromFirebaseAsync();
            }
            // DATA_SOURCE == 2: Carga ambas fuentes de datos
            else if (State.DATA_SOURCE == 2)
            {
                LoadDummyVehicles();
                await LoadVehiclesFromFirebaseAsync();
            }
        }

        public static async Task<string> AddVehicleAsync(VehicleModel vehicle)
        {
            var result = await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .PostAsync(vehicle);
            return result.Key;
        }

        public static async Task<List<VehicleModel>> GetAllVehiclesAsync()
        {
            return (await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .OnceAsync<VehicleModel>())
                .Select(item => item.Object)
                .ToList();
        }

        public static async Task UpdateVehicleAsync(string key, VehicleModel vehicle)
        {
            await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .Child(key)
                .PutAsync(vehicle);
        }

        public static async Task DeleteVehicleAsync(string key)
        {
            await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .Child(key)
                .DeleteAsync();
        }
    }
}

