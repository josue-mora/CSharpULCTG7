using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class VehicleDbDummies
    {
        public static List<VehicleModel> CreateVehicles()
        {
            //return new List<VehicleModel>();
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            vehicleModels.Add(new VehicleModel("Coupe", "CLA", 2025, 0, "NEW", "Auto blanco", "cla_amg.png"));
            vehicleModels.Add(new VehicleModel("Coupe", "GLE Coupe", 2025, 0, "NEW", "Auto blanco", "gle_coupe_amg.png"));
            vehicleModels.Add(new VehicleModel("Roadster", "Mercedes AMG SL", 2025, 0, "NEW", "Auto blanco", "roadster_amg_sl.png"));
            vehicleModels.Add(new VehicleModel("Hatchback", "Clase A Hatchback", 2025, 0, "NEW", "Auto blanco", "clase_a_hatchback.png"));
            vehicleModels.Add(new VehicleModel("Sedan", "EQS Sedan", 2025, 0, "NEW", "Auto blanco", "eqs_sedan.png"));
            vehicleModels.Add(new VehicleModel("Sedan", "Mercedes AMG Clase A Sedan", 2025, 0, "NEW", "Auto blanco", "clase_a_sedan.png"));
            vehicleModels.Add(new VehicleModel("Sedan", "Clase C Sedan", 2025, 0, "NEW", "Auto blanco", "clase_c_sedan.png"));
            vehicleModels.Add(new VehicleModel("Sedan", "Clase E Sedan", 2025, 0, "NEW", "Auto blanco", "clase_e_sedan.png"));
            vehicleModels.Add(new VehicleModel("SUV", "GLC SUV", 2025, 0, "NEW", "Auto blanco", "glc_suv.png"));
            vehicleModels.Add(new VehicleModel("SUV", "EQE SUV", 2025, 0, "NEW", "Auto blanco", "eqe.png"));
            vehicleModels.Add(new VehicleModel("SUV", "GLA SUV", 2025, 0, "NEW", "Auto blanco", "gla_suv.png"));
            vehicleModels.Add(new VehicleModel("SUV", "GLE SUV", 2025, 0, "NEW", "Auto blanco", "gle_suv.png"));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G", 2025, 0, "NEW", "Auto blanco", "clase_g_suv.png"));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G63", 2025, 0, "NEW", "Auto blanco", "clase_g63_suv.png"));
            return vehicleModels;
        }
    }
}
