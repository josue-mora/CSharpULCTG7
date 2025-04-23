using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;
using Firebase.Database.Query;

namespace LCSharpMBG7.Code.Controllers
{
    public class VehicleController
    {
        private static void LoadDummyVehicles()
        {
            State.vehicles = VehicleDbDummies.CreateVehicles();
        }

        private static async Task LoadVehiclesFromFirebaseAsync()
        {
            var list = await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .OnceAsync<VehicleModel>();
            State.vehicles = list.Select(x => x.Object).ToList();
        }

        public static async Task LoadVehiclesAsync()
        {
            if (State.DATA_SOURCE == 0)
            {
                if (State.vehicles == null || State.vehicles.Count == 0)
                    LoadDummyVehicles();
            }
            else if (State.DATA_SOURCE == 1)
            {
                await LoadVehiclesFromFirebaseAsync();
            }
            else // both
            {
                if (State.vehicles == null || State.vehicles.Count == 0)
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

            var result = await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .PostAsync(vehicle);
            vehicle.Id = result.Key;
            State.vehicles.Add(vehicle);
            await FirebaseHelper.CreateConnection()
                .Child("Vehicles")
                .Child(result.Key)
                .PutAsync(vehicle);
            return result.Key;
        }

        public static async Task UpdateVehicleAsync(string key, VehicleModel vehicle)
        {
            var idx = State.vehicles.FindIndex(v => v.Id == key);
            if (idx >= 0) State.vehicles[idx] = vehicle;

            if (State.DATA_SOURCE != 0)
                await FirebaseHelper.CreateConnection()
                    .Child("Vehicles")
                    .Child(key)
                    .PutAsync(vehicle);
        }

        public static async Task DeleteVehicleAsync(string key)
        {
            var idx = State.vehicles.FindIndex(v => v.Id == key);
            if (idx >= 0) State.vehicles.RemoveAt(idx);

            if (State.DATA_SOURCE != 0)
                await FirebaseHelper.CreateConnection()
                    .Child("Vehicles")
                    .Child(key)
                    .DeleteAsync();
        }
    }
}
