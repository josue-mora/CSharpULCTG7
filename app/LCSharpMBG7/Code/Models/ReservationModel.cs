using LCSharpMBG7.Code.Logical;
using Newtonsoft.Json;


namespace LCSharpMBG7.Code.Models
{
    public class ReservationModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("id_vehicle")]
        public string IdVehicle { get; set; }

        [JsonProperty("date_reservation")]
        public string DateReservation { get; set; }

        [JsonProperty("date_appointment")]
        public string DateAppointment { get; set; }

        [JsonProperty("client_id_card_number")]
        public string ClientIdCardNumber { get; set; }

        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [JsonProperty("client_comment")]
        public string ClientComment { get; set; }

        public ReservationModel() { }

        public ReservationModel(
            string id_vehicle,
            string date_reservation,
            string date_appointment,
            string client_id_card_number,
            string client_name,
            string client_comment)
        {
            this.Id = "" + DateFormatter.GetUNIXTimestamp();

            this.IdVehicle = id_vehicle;
            this.DateReservation = (!string.IsNullOrWhiteSpace(date_reservation) && date_reservation.Length >= 8)
                                        ? date_reservation
                                        : "" + DateFormatter.GetUNIXTimestamp();
            this.DateAppointment = (!string.IsNullOrWhiteSpace(date_appointment) && date_appointment.Length >= 8)
                                        ? date_appointment
                                        : "" + DateFormatter.GetUNIXTimestamp();
            this.ClientIdCardNumber = (!string.IsNullOrWhiteSpace(client_id_card_number) && client_id_card_number.All(char.IsDigit))
                                        ? client_id_card_number.Trim()
                                        : "122223333";
            this.ClientName = (!string.IsNullOrWhiteSpace(client_name) && client_name.Trim().Length > 1)
                                        ? client_name.Trim()
                                        : "John Doe";
            this.ClientComment = string.IsNullOrEmpty(client_comment) ? "N/A" : client_comment;
        }

        public override string ToString()
        {
            return $"Reserva. ID Vehículo: {IdVehicle} | Cliente: {ClientName} ({ClientIdCardNumber}) | " +
                   $"Reserva: {DateFormatter.FormatUNIXToDate(DateReservation)} | Cita: {DateFormatter.FormatUNIXToDate(DateAppointment)}";
        }
    }
}
