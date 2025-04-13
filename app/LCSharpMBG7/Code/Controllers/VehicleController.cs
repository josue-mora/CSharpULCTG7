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
        private static void LoadDummyVehicles()
        {
            List<VehicleModel> vehicleModels = VehicleDbDummies.CreateVehicles();
            State.vehicles = vehicleModels;
        }

        // Carga vehículos de forma asíncrona desde Firebase
        private static async Task LoadVehiclesFromFirebaseAsync()
        {
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
        public static async Task LoadVehiclesAsync()
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
            if (State.DATA_SOURCE == 0)
            {
                State.vehicles.Add(vehicle);
                return vehicle.Id;
            }
            // 1
            else
            {
                // Post object on db.
                var result = await FirebaseHelper.CreateConnection()
                    .Child("Vehicles")
                    .PostAsync(vehicle);
                // Saves unique Firebase key in Id property and memory.
                vehicle.Id = result.Key;
                State.vehicles.Add(vehicle);
                // Updates Id property in object saved on the DB.
                await FirebaseHelper.CreateConnection()
                    .Child("Vehicles")
                    .Child(result.Key)
                    .PutAsync(vehicle);
                return result.Key;
            }
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
            for (int i = 0; i < State.vehicles.Count; i++)
            {
                if (State.vehicles[i].Id == key)
                {
                    State.vehicles[i] = vehicle;
                    break;
                }
            }
            if (State.DATA_SOURCE == 1)
            {
                await FirebaseHelper.CreateConnection()
                    .Child("Vehicles")
                    .Child(key)
                    .PutAsync(vehicle);
            }
        }

        public static async Task DeleteVehicleAsync(string key)
        {
            for (int i = State.vehicles.Count - 1; i >= 0; i--)
            {
                if (State.vehicles[i].Id == key)
                {
                    State.vehicles.RemoveAt(i);
                    break;
                }
            }
            if (State.DATA_SOURCE == 1)
            {
                await FirebaseHelper.CreateConnection()
                    .Child("Vehicles")
                    .Child(key)
                    .DeleteAsync();
            }
        }
    }
}
