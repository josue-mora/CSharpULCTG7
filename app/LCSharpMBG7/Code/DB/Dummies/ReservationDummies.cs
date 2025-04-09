using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.DB.Dummies
{
    // Clase que contiene datos de prueba para reservaciones
    public class ReservationDummies
    {
        // Método que crea y retorna una lista de reservaciones de prueba
        public static List<ReservationModel> CreateReservations()
        {
            // Inicializa la lista vacía de modelos de reservación
            List<ReservationModel> models = new List<ReservationModel>();

            // Genera un ID predeterminado para el auto vendido usando marca de tiempo UNIX
            string sold_car_id = DateFormatter.GetUNIXTimestamp().ToString();
            if (State.vehicles != null && State.vehicles.Count > 0)
            {
                // Usa la propiedad pública 'Id' del vehículo
                sold_car_id = State.vehicles[0].Id;
            }

            // Crea una reservación con datos de prueba y la agrega a la lista
            models.Add(new ReservationModel(
                sold_car_id,
                DateFormatter.GetUNIXTimestamp().ToString(),
                DateFormatter.GetUNIXTimestamp().ToString(),
                "12223333",
                "John Doe",
                "Color blanco."
            ));

            // Devuelve la lista de reservaciones
            return models;
        }
    }
}
