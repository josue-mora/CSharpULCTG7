using Firebase.Database;
using Firebase.Database.Query;
using LCSharpMBG7.Code.Models;


namespace LCSharpMBG7.Code.Services
{
    // Clase auxiliar para manejar operaciones con Firebase
    public class FirebaseHelper
    {
        // Cliente de Firebase para realizar operaciones con la base de datos
        private readonly FirebaseClient firebase;

        // Constructor que inicializa la conexión con Firebase
        public FirebaseHelper()
        {
            firebase = new FirebaseClient("https://mercedesshowroom-679f7-default-rtdb.firebaseio.com/");
        }

        // ------------------------------
        // Operaciones CRUD de Reservaciones
        // ------------------------------

        // Agrega una nueva reservación y devuelve su ID
        public async Task<string> AddReservationAsync(ReservationModel reservation)
        {
            var result = await firebase
                .Child("Reservations")
                .PostAsync(reservation);
            // La propiedad Key contiene el identificador único generado por Firebase
            return result.Key;
        }

        // Obtiene todas las reservaciones existentes
        public async Task<List<ReservationModel>> GetAllReservationsAsync()
        {
            return (await firebase
                .Child("Reservations")
                .OnceAsync<ReservationModel>())
                .Select(item => item.Object)
                .ToList();
        }

        // Obtiene una reservación específica por su ID
        public async Task<ReservationModel> GetReservationAsync(string key)
        {
            return await firebase
                .Child("Reservations")
                .Child(key)
                .OnceSingleAsync<ReservationModel>();
        }

        // Actualiza una reservación existente
        public async Task UpdateReservationAsync(string key, ReservationModel reservation)
        {
            await firebase
                .Child("Reservations")
                .Child(key)
                .PutAsync(reservation);
        }

        // Elimina una reservación por su ID
        public async Task DeleteReservationAsync(string key)
        {
            await firebase
                .Child("Reservations")
                .Child(key)
                .DeleteAsync();
        }


        // ------------------------------
        // Operaciones CRUD de Ventas
        // ------------------------------

        // Agrega una nueva venta y devuelve su ID
        public async Task<string> AddSellAsync(SellModel sell)
        {
            var result = await firebase
                .Child("Sells")
                .PostAsync(sell);
            return result.Key;
        }

        // Obtiene todas las ventas registradas
        public async Task<List<SellModel>> GetAllSellsAsync()
        {
            return (await firebase
                .Child("Sells")
                .OnceAsync<SellModel>())
                .Select(item => item.Object)
                .ToList();
        }

        // Actualiza una venta existente
        public async Task UpdateSellAsync(string key, SellModel sell)
        {
            await firebase
                .Child("Sells")
                .Child(key)
                .PutAsync(sell);
        }

        // Elimina una venta por su ID
        public async Task DeleteSellAsync(string key)
        {
            await firebase
                .Child("Sells")
                .Child(key)
                .DeleteAsync();
        }


        // ------------------------------
        // Operaciones CRUD de Usuarios
        // ------------------------------

        // Agrega un nuevo usuario y devuelve su ID
        public async Task<string> AddUserAsync(UserModel user)
        {
            var result = await firebase
                .Child("Users")
                .PostAsync(user);
            return result.Key;
        }

        // Obtiene todos los usuarios registrados
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return (await firebase
                .Child("Users")
                .OnceAsync<UserModel>())
                .Select(item => item.Object)
                .ToList();
        }

        // Actualiza un usuario existente
        public async Task UpdateUserAsync(string key, UserModel user)
        {
            await firebase
                .Child("Users")
                .Child(key)
                .PutAsync(user);
        }

        // Elimina un usuario por su ID
        public async Task DeleteUserAsync(string key)
        {
            await firebase
                .Child("Users")
                .Child(key)
                .DeleteAsync();
        }


        // ------------------------------
        // Operaciones CRUD de Vehículos
        // ------------------------------

        // Agrega un nuevo vehículo y devuelve su ID
        public async Task<string> AddVehicleAsync(VehicleModel vehicle)
        {
            var result = await firebase
                .Child("Vehicles")
                .PostAsync(vehicle);
            return result.Key;
        }

        // Obtiene todos los vehículos registrados
        public async Task<List<VehicleModel>> GetAllVehiclesAsync()
        {
            return (await firebase
                .Child("Vehicles")
                .OnceAsync<VehicleModel>())
                .Select(item => item.Object)
                .ToList();
        }

        // Actualiza un vehículo existente
        public async Task UpdateVehicleAsync(string key, VehicleModel vehicle)
        {
            await firebase
                .Child("Vehicles")
                .Child(key)
                .PutAsync(vehicle);
        }

        // Elimina un vehículo por su ID
        public async Task DeleteVehicleAsync(string key)
        {
            await firebase
                .Child("Vehicles")
                .Child(key)
                .DeleteAsync();
        }
    }
}
