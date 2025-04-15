using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class VehicleDbDummies
    {
        public static List<VehicleModel> CreateVehicles()
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            vehicleModels.Add(new VehicleModel("Hatchback", "claseA", 2025, 500000, "NEW", "Auto blanco", null).SetImageCarousel("hatchback.jpg"));
            vehicleModels.Add(new VehicleModel("Sedán", "EQS", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("eqs.jpg"));
            vehicleModels.Add(new VehicleModel("Sedán", "ClaseC", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("clasec.jpg"));
            vehicleModels.Add(new VehicleModel("Sedán", "ClaseA", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("clasea.jpg"));
            vehicleModels.Add(new VehicleModel("SUV", "GLA SUV", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg") );
            vehicleModels.Add(new VehicleModel("SUV", "GLC", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg"));
            vehicleModels.Add(new VehicleModel("SUV", "EQE", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg"));
            vehicleModels.Add(new VehicleModel("SUV", "GLE", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg"));
            vehicleModels.Add(new VehicleModel("SUV", "GLC Coupé", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg"));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg")   );
            vehicleModels.Add(new VehicleModel("SUV", "Clase G63", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg"));
            vehicleModels.Add(new VehicleModel("Coupé", "Clase G - 2", 2025, 500000, "NEW", "Lorem Ipsum", null).SetImageCarousel("gla.jpg"));
            return vehicleModels;
        }
    }
}
