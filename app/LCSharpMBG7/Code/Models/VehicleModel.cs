using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    public class VehicleModel
    {
        private string id;
        private string model; // Car Body (carroceria).
        private string name;
        private int year;
        private int price; // Price in CRC. No decimals.
        private string state; // Used or new.
        private string page_content; // JSON structure.
        private bool active;

        public VehicleModel()
        {
            this.SetId()
            // Default values.
                .SetModel("SUV")
                .SetName("GLA")
                .SetYear(2025)
                .SetPrice(5000000)
                .SetState("NEW")
                .SetPageContent("")
                .SetActive(true);
        }

        public VehicleModel(string model, string name, int year, int price, string state, string page_content)
        {
            this.SetId()
                .SetModel(model)
                .SetName(name)
                .SetYear(year)
                .SetPrice(price)
                .SetState(state)
                .SetPageContent(page_content)
                .SetActive(true);
        }

        // ------------------------------------------------
        // Get and Set.
        // ------------------------------------------------

        public string GetId()
        {
            return this.id;
        }

        public VehicleModel SetId()
        {
            // Generates an ID based on UNIX time.
            DateTimeOffset dto = DateTimeOffset.UtcNow;
            long unixTime = dto.ToUnixTimeSeconds();
            this.id = unixTime + "";
            return this;
        }

        public string GetModel()
        {
            return this.model;
        }

        /// <summary>
        /// Sets vehicle model.
        /// </summary>
        /// <param name="model">
        /// The vehicle model listed in Constants.VEHICLE_MODELS.
        /// </param>
        /// <returns>Current Vehicle instance for chaining.</returns>
        public VehicleModel SetModel(string model)
        {
            if (Constants.VEHICLE_MODELS.Contains(model))
            {
                this.model = model;
            }
            else
            {
                Console.WriteLine($"Invalid vehicle model '{model}'.");
                this.model = Constants.VEHICLE_MODELS[0];
            }
            return this;
        }

        public string GetName()
        {
            return this.name;
        }

        public VehicleModel SetName(string name)
        {
            this.name = name;
            return this;
        }

        public int GetYear()
        {
            return this.year;
        }

        public VehicleModel SetYear(int year)
        {
            if (year > 2025)
            {
                this.year = 2025;
                return this;
            }
            else if (year < 1926)
            {
                this.year = 1926;
                return this;
            }
            this.year = year;
            return this;
        }

        public int GetPrice()
        {
            return this.price;
        }

        public VehicleModel SetPrice(int price)
        {
            if (price < 0)
            {
                this.price = 5000000;
            }
            this.price = price;
            return this;
        }

        public string GetState()
        {
            return this.state;
        }

        public VehicleModel SetState(string state)
        {
            if (Constants.VEHICLE_STATES.Contains(state))
            {
                this.state = state;
            }
            else
            {
                Console.WriteLine($"Invalid vehicle state '{state}'.");
                this.state = Constants.VEHICLE_STATES[0];
            }
            return this;
        }

        public string GetPageContent()
        {
            return this.page_content;
        }

        public VehicleModel SetPageContent(string page_content)
        {
            this.page_content = page_content;
            return this;
        }

        public bool GetActive()
        {
            return this.active;
        }

        public VehicleModel SetActive(bool active)
        {
            this.active = active;
            return this;
        }

        // ------------------------------------------------
        // Utils.
        // ------------------------------------------------
        public override string ToString()
        {
            return $"Vehículo. Modelo: {this.model}. Nombre: {this.name}.";
        }
    }
}
