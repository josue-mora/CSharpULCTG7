using LCSharpMBG7.Code.Logical;
using Newtonsoft.Json;

namespace LCSharpMBG7.Code.Models
{
    // Clase que representa una venta de vehículo
    public class SellModel
    {
        // Identificador único de la venta
        [JsonProperty("id")]
        public string Id { get; set; }

        // Identificador del vehículo vendido
        [JsonProperty("id_vehicle")] 
        public string IdVehicle { get; set; }

        // Fecha en que se realizó la venta
        [JsonProperty("date_sell")]
        public string DateSell { get; set; }

        // Número de documento de identidad del cliente
        [JsonProperty("client_id_card_number")]
        public string ClientIdCardNumber { get; set; }

        // Nombre completo del cliente
        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        // Constructor por defecto necesario para la deserialización JSON
        public SellModel() { }

        // Constructor con parámetros que aplica la lógica de validación
        public SellModel(
            string id_vehicle,
            string date_sell, 
            string client_id_card_number,
            string client_name)
        {
            // Genera un ID único basado en el timestamp UNIX actual
            this.Id = "" + DateFormatter.GetUNIXTimestamp();

            // Establece el ID del vehículo
            this.IdVehicle = id_vehicle;

            // Valida y establece la fecha de venta
            // Si la fecha es válida la usa, sino usa el timestamp actual
            if (!string.IsNullOrWhiteSpace(date_sell) && date_sell.Length >= 8)
            {
                this.DateSell = date_sell;
            }
            else
            {
                this.DateSell = "" + DateFormatter.GetUNIXTimestamp();
            }

            // Valida y establece el número de documento del cliente
            // Debe contener solo dígitos, sino usa un valor por defecto
            if (!string.IsNullOrWhiteSpace(client_id_card_number) && client_id_card_number.All(char.IsDigit))
            {
                this.ClientIdCardNumber = client_id_card_number.Trim();
            }
            else
            {
                this.ClientIdCardNumber = "122223333";
            }

            // Valida y establece el nombre del cliente
            // Debe tener al menos 2 caracteres, sino usa un nombre por defecto
            if (!string.IsNullOrWhiteSpace(client_name) && client_name.Trim().Length > 1)
            {
                this.ClientName = client_name.Trim();
            }
            else
            {
                this.ClientName = "John Doe";
            }
        }

        // Sobreescribe el método ToString para mostrar un resumen de la venta
        public override string ToString()
        {
            return $"Venta. ID Vehiculo: {this.IdVehicle}. Comprador: {this.ClientName} - {this.ClientIdCardNumber}";
        }
    }
}
