using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;

namespace LCSharpMBG7.Code.Controllers
{
    // Controlador para probar la funcionalidad de Firebase
    public class FirebaseTestController
    {
        // Método asíncrono para probar todos los modelos en Firebase
        public async Task TestAllModelsFirebaseAsync()
        {
            try
            {
                // ========= Prueba de Vehículo =========
                // Crear un registro de vehículo de prueba
                VehicleModel testVehicle = new VehicleModel(
                    "SUV", 
                    "Test Vehicle", 
                    2025, 
                    1000000, 
                    "NEW", 
                    "Test vehicle for Firebase connection.", 
                    null,
                    false);
                // Insertar vehículo en Firebase y capturar la clave generada
                string vehicleKey = await VehicleController.AddVehicleAsync(testVehicle);
                System.Diagnostics.Debug.WriteLine("Vehicle inserted with Firebase key: " + vehicleKey);

                // ========= Prueba de Reservación =========
                // Usar el ID del vehículo de prueba para asociar la reservación
                string testVehicleId = testVehicle.Id;
                ReservationModel testReservation = new ReservationModel(
                    testVehicleId, 
                    DateFormatter.GetUNIXTimestamp().ToString(), 
                    DateFormatter.GetUNIXTimestamp().ToString(), 
                    "12223333", 
                    "John Doe", 
                    "Reservation test record.");
                string reservationKey = await ReservationController.AddReservationAsync(testReservation);
                System.Diagnostics.Debug.WriteLine("Reservation inserted with Firebase key: " + reservationKey);

                // ========= Prueba de Venta =========
                // Crear un registro de venta usando el mismo vehículo
                SellModel testSell = new SellModel(
                    testVehicleId, 
                    DateFormatter.GetUNIXTimestamp().ToString(), 
                    "122223333", 
                    "John Doe");
                string sellKey = await SellController.AddSellAsync(testSell);
                System.Diagnostics.Debug.WriteLine("Sell inserted with Firebase key: " + sellKey);

                // ========= Prueba de Usuario =========
                // Crear un usuario de prueba. Aquí puedes usar tu lógica personalizada de creación de usuario o simplemente crear uno nuevo
                UserModel testUser = new UserModel(
                    "TestID", 
                    "Test User", 
                    "test@mail.com", 
                    "test123", 
                    0);
                string userKey = await UserController.AddUserAsync(testUser);
                System.Diagnostics.Debug.WriteLine("User inserted with Firebase key: " + userKey);

                // Opcionalmente, agregar un pequeño retraso o llamar operaciones de lectura para verificar los datos insertados
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error durante la prueba de Firebase para todos los modelos: " + ex.Message);
            }
        }
    }
}
