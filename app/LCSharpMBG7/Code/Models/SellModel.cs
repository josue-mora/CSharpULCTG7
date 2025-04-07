using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    public class SellModel
    {

        private string id;
        private string id_vehicle;
        private string date_sell;
        private string client_id_card_number;
        private string client_name;

        public SellModel() { }

        public SellModel
        (
            string id_vehicle,
            string date_sell,
            string client_id_card_number,
            string client_name
        )
        {
            this.SetId()
                .SetIdVehicle(id_vehicle)
                .SetDateSell(date_sell)
                .SetClientIdCardNumber(client_id_card_number)
                .SetClientName(client_name);
        }

        // ================================================
        // Get and Set.
        // ================================================

        public string GetId()
        {
            return id;
        }

        public SellModel SetId()
        {
            this.id = "" + DateFormatter.GetUNIXTimestamp();
            return this;
        }

        public string GetIdVehicle()
        {
            return id;
        }

        public SellModel SetIdVehicle(string id_vehicle)
        {
            this.id_vehicle = id_vehicle;
            return this;
        }

        public string GetDateSell()
        {
            return date_sell;
        }

        public SellModel SetDateSell(string date)
        {
            if (!string.IsNullOrWhiteSpace(date) && date.Length >= 8)
            {
                this.date_sell = date;
            }
            else
            {
                this.date_sell = "" + DateFormatter.GetUNIXTimestamp();
            }
            return this;
        }

        public string GetClientIdCardNumber()
        {
            return client_id_card_number;
        }

        public SellModel SetClientIdCardNumber(string client_id_card_number)
        {
            if (!string.IsNullOrWhiteSpace(client_id_card_number) &&
                client_id_card_number.All(char.IsDigit))
            {
                this.client_id_card_number = client_id_card_number.Trim();
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

        public SellModel SetClientName(string client_name)
        {
            // "Xi" is a Chinese name, so 2 as length is valid.
            if (!string.IsNullOrWhiteSpace(client_name) && client_name.Trim().Length > 1)
            {
                this.client_name = client_name.Trim();
            }
            else
            {
                this.client_name = "John Doe";
            }
            return this;
        }

        public override string ToString()
        {
            return $"Venta. ID Vehiculo: {this.id_vehicle}. Comprador: {this.client_name} - {this.client_id_card_number}";
        }
    }
}
