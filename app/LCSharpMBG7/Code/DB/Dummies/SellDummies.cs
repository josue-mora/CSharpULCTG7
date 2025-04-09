using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    // Clase que genera datos ficticios de ventas
    public class SellDummies
    {
        // Método que crea y devuelve una lista de registros de venta ficticios
        public static List<SellModel> CreateSells()
        {
            // Inicializa la lista vacía de modelos de venta
            List<SellModel> sellModels = new List<SellModel>();

            // Crea un ID predeterminado para el auto vendido usando marca de tiempo UNIX
            string sold_car_id = DateFormatter.GetUNIXTimestamp().ToString();
            // Si hay vehículos disponibles, usa el ID del primer vehículo
            if (State.vehicles != null && State.vehicles.Count > 0)
            {
                sold_car_id = State.vehicles[0].Id;
            }

            // Crea un registro de venta con datos ficticios y lo agrega a la lista
            sellModels.Add(new SellModel(
                sold_car_id,                                    // ID del auto vendido
                DateFormatter.GetUNIXTimestamp().ToString(),    // Fecha de venta como marca de tiempo
                "122223333",                                   // Número de identificación del cliente
                "John Doe"                                     // Nombre del cliente
            ));
            return sellModels;
        }
    }
}
