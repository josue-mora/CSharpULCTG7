using Newtonsoft.Json;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    // Clase que representa un modelo de vehículo
    public class VehicleModel
    {
        // Propiedades públicas decoradas con JsonProperty para serialización
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("model")] 
        public string Model { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("page_content")]
        public string PageContent { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("image_carousel")]
        public string ImageCarousel { get; set; }

        // Constructor por defecto con valores predeterminados
        public VehicleModel()
        {
            // Genera un ID único usando timestamp UNIX
            this.Id = DateFormatter.GetUNIXTimestamp().ToString();

            // Valida y asigna valores por defecto
            this.Model = Constants.VEHICLE_MODELS.Contains("SUV") ? "SUV" : Constants.VEHICLE_MODELS.First();
            this.Name = "GLA";
            this.Year = 2025;
            this.Price = 5000000;
            this.State = Constants.VEHICLE_STATES.Contains("NEW") ? "NEW" : Constants.VEHICLE_STATES.First();
            this.PageContent = "";
            this.Active = true;
            this.ImageCarousel = "missing_asset.png";
        }

        // Constructor parametrizado que aplica lógica de validación
        public VehicleModel(string model, string name, int year, int price, string state, string page_content, string image_carousel)
        {
            // Genera un ID único
            this.Id = DateFormatter.GetUNIXTimestamp().ToString();

            // Valida el modelo
            if (Constants.VEHICLE_MODELS.Contains(model))
            {
                this.Model = model;
            }
            else
            {
                Console.WriteLine($"Modelo de vehículo inválido '{model}'.");
                this.Model = Constants.VEHICLE_MODELS.First();
            }

            // Asigna el nombre
            this.Name = name;

            // Valida el año
            if (year > 2025)
            {
                this.Year = 2025;
            }
            else if (year < 1926)
            {
                this.Year = 1926;
            }
            else
            {
                this.Year = year;
            }

            // Valida el precio
            if (price < 0)
            {
                this.Price = 5000000;
            }
            else
            {
                this.Price = price;
            }

            // Valida el estado
            if (Constants.VEHICLE_STATES.Contains(state))
            {
                this.State = state;
            }
            else
            {
                Console.WriteLine($"Estado de vehículo inválido '{state}'.");
                this.State = Constants.VEHICLE_STATES.First();
            }

            // Asigna el contenido de la página
            this.PageContent = page_content;

            // Establece el vehículo como activo
            this.Active = true;

            // Valida la imagen del carrusel
            if (string.IsNullOrWhiteSpace(image_carousel))
            {
                this.ImageCarousel = "missing_asset.png";
            }
            else
            {
                this.ImageCarousel = image_carousel;
            }
        }

        // ------------------------------------------------
        // Utils.
        // ------------------------------------------------

        // Sobreescribe el método ToString para mostrar información del vehículo
        public override string ToString()
        {
            return $"Vehículo. Modelo: {this.Model}. Nombre: {this.Name}. Imagen: {this.ImageCarousel}";
        }
    }
}
