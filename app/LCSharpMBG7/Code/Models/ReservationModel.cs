using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    public class ReservationModel
    {
        private string id;
        private string id_vehicle;
        private string date_reservation;
        private string date_appointment;
        private string client_id_card_number;
        private string client_name;
        private string client_comment;

        public ReservationModel() { }

        public ReservationModel(
            string id_vehicle,
            string date_reservation,
            string date_appointment,
            string client_id_card_number,
            string client_name,
            string client_comment)
        {
            this.SetId()
                .SetIdVehicle(id_vehicle)
                .SetDateReservation(date_reservation)
                .SetDateAppointment(date_appointment)
                .SetClientIdCardNumber(client_id_card_number)
                .SetClientName(client_name)
                .SetClientComment(client_comment);
        }

        public string GetId()
        {
            return id;
        }

        public ReservationModel SetId()
        {
            this.id = "" + DateFormatter.GetUNIXTimestamp();
            return this;
        }

        public string GetIdVehicle()
        {
            return id_vehicle;
        }

        public ReservationModel SetIdVehicle(string id_vehicle)
        {
            this.id_vehicle = id_vehicle;
            return this;
        }

        public string GetDateReservation()
        {
            return date_reservation;
        }

        public ReservationModel SetDateReservation(string date)
        {
            if (!string.IsNullOrWhiteSpace(date) && date.Length >= 8)
            {
                this.date_reservation = date;
            }
            else
            {
                this.date_reservation = "" + DateFormatter.GetUNIXTimestamp();
            }
            return this;
        }

        public string GetDateAppointment()
        {
            return date_appointment;
        }

        public ReservationModel SetDateAppointment(string date)
        {
            if (!string.IsNullOrWhiteSpace(date) && date.Length >= 8)
            {
                this.date_appointment = date;
            }
            else
            {
                this.date_appointment = "" + DateFormatter.GetUNIXTimestamp();
            }
            return this;
        }

        public string GetClientIdCardNumber()
        {
            return client_id_card_number;
        }

        public ReservationModel SetClientIdCardNumber(string idNumber)
        {
            if (!string.IsNullOrWhiteSpace(idNumber) && idNumber.All(char.IsDigit))
            {
                this.client_id_card_number = idNumber.Trim();
            }
            else
            {
                this.client_id_card_number = "122223333";
            }
            return this;
        }

        public string GetClientName()
        {
            return client_name;
        }

        public ReservationModel SetClientName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Trim().Length > 1)
            {
                this.client_name = name.Trim();
            }
            else
            {
                this.client_name = "John Doe";
            }
            return this;
        }

        public string GetClientComment()
        {
            return client_comment;
        }

        public ReservationModel SetClientComment(string comment)
        {
            if (comment == null || comment == "")
            {
                this.client_comment = "N/A";
            }
            else
            {
                this.client_comment = comment;
            }
            return this;
        }

        public override string ToString()
        {
            return $"Reserva. ID Vehículo: {id_vehicle} | Cliente: {client_name} ({client_id_card_number}) | " +
                   $"Reserva: {DateFormatter.FormatUNIXToDate(date_reservation)} | Cita: {DateFormatter.FormatUNIXToDate(date_appointment)}";
        }
    }
}
