using LCSharpMBG7.Code.Models;
using System.Collections.Generic;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class VehicleDbDummies
    {
        public static List<VehicleModel> CreateVehicles()
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            vehicleModels.Add(new VehicleModel("SUV", "GLA", 2025, 0, "NEW", "Auto blanco", null));
            vehicleModels.Add(new VehicleModel("SUV", "EQA", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "EQB", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "EQE", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "GLC Coupé", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "EQS", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "GLE Coupé", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "GLC", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "GLE", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "GLS", 2025, 0, "NEW", "Lorem Ipsum", null));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G - 2", 2025, 0, "NEW", "Lorem Ipsum", null));
            return vehicleModels;
        }
    }
}
