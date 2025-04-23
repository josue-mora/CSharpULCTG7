using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class VehicleDbDummies
    {
        public static List<VehicleModel> CreateVehicles()
        {
            //return new List<VehicleModel>();
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            vehicleModels.Add(new VehicleModel("Coupé", "CLA", 2025, 0, "NEW", "Auto blanco", "cla_amg.png", true));
            vehicleModels.Add(new VehicleModel("Coupé", "GLE Coupé", 2025, 0, "NEW", "Auto blanco", "gle_coupe_amg.png", true));
            vehicleModels.Add(new VehicleModel("Hatchback", "Mercedes AMG SL", 2025, 0, "NEW", "Auto blanco", "roadster_amg_sl.png", true));
            vehicleModels.Add(new VehicleModel("Hatchback", "Clase A Hatchback", 2025, 0, "NEW", "Auto blanco", "clase_a_hatchback.png", true));
            vehicleModels.Add(new VehicleModel("Sedán", "EQS Sedán", 2025, 0, "NEW", "Auto blanco", "eqs_sedan.png", true));
            vehicleModels.Add(new VehicleModel("Sedán", "Mercedes AMG Clase A Sedan", 2025, 0, "NEW", "Auto blanco", "clase_a_sedan.png", true));
            vehicleModels.Add(new VehicleModel("Sedán", "Clase C Sedán", 2025, 0, "NEW", "Auto blanco", "clase_c_sedan.png", true));
            vehicleModels.Add(new VehicleModel("Sedán", "Clase E Sedán", 2025, 0, "NEW", "Auto blanco", "clase_e_sedan.png", true));
            vehicleModels.Add(new VehicleModel("SUV", "GLC SUV", 2025, 0, "NEW", "Auto blanco", "glc_suv.png", true));
            vehicleModels.Add(new VehicleModel("SUV", "EQE SUV", 2025, 0, "NEW", "Auto blanco", "eqe_suv.png", true));
            vehicleModels.Add(new VehicleModel("SUV", "GLA SUV", 2025, 0, "NEW", "Auto blanco", "gla_suv.png", true));
            vehicleModels.Add(new VehicleModel("SUV", "GLE SUV", 2025, 0, "NEW", "Auto blanco", "gle_suv.png", true));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G", 2025, 0, "NEW", "Auto blanco", "clase_g_suv.png", true));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G63", 2025, 0, "NEW", "Auto blanco", "clase_g63_suv.png", true));

            // IDs are settled too fast so they repeat. This loop give unique IDs.
            for (int i = 0; i < vehicleModels.Count; i++) vehicleModels[i].Id = vehicleModels[i].Id + i;

            // Dev placeholder.
            vehicleModels[vehicleModels.Count - 1].PageContent = @"T_TITLE_1Mi vehiculo Clase G63";

            return vehicleModels;
        }
    }
}
