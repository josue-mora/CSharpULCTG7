using LCSharpMBG7.Code.Helpers;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class VehicleDbDummies
    {
        public static List<VehicleModel> CreateVehicles()
        {
            //return new List<VehicleModel>();
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            // Sendans
            vehicleModels.Add(new VehicleModel("Sedán", "Clase A Sedán", 2025, 12000000, "NEW", VehiclePageDescriptionHelper.GetContent(0), "cla_a_sedan.png", false));
            vehicleModels.Add(new VehicleModel("Sedán", "EQS Sedán", 2025, 12000000, "NEW", VehiclePageDescriptionHelper.GetContent(1), "eqs_sedan.png", false));
            vehicleModels.Add(new VehicleModel("Sedán", "Mercedes AMG Clase A Sedan", 2025, 38000000, "NEW", VehiclePageDescriptionHelper.GetContent(2), "clase_a_sedan.png", true));
            vehicleModels.Add(new VehicleModel("Sedán", "Clase C Sedán", 2025, 10000000, "NEW", VehiclePageDescriptionHelper.GetContent(3), "clase_c_sedan.png", false));
            vehicleModels.Add(new VehicleModel("Sedán", "Clase E Sedán", 2025, 10000000, "NEW", VehiclePageDescriptionHelper.GetContent(4), "clase_e_sedan.png", false));
            // Coupes
            vehicleModels.Add(new VehicleModel("Coupé", "CLA", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(5), "cla_amg.png", false));
            vehicleModels.Add(new VehicleModel("Coupé", "GLE Coupé", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(6), "gle_coupe_amg.png", false));
            // Hatchback
            vehicleModels.Add(new VehicleModel("Hatchback", "Mercedes AMG SL", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(7), "roadster_amg_sl.png", true));
            vehicleModels.Add(new VehicleModel("Hatchback", "Clase A Hatchback", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(8), "clase_a_hatchback.png", false));
            // SUVs
            vehicleModels.Add(new VehicleModel("SUV", "GLC SUV", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(9), "glc_suv.png", false));
            vehicleModels.Add(new VehicleModel("SUV", "EQE SUV", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(10), "eqe_suv.png", false));
            vehicleModels.Add(new VehicleModel("SUV", "GLA SUV", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(11), "gla_suv.png", false));
            vehicleModels.Add(new VehicleModel("SUV", "GLE SUV", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(12), "gle_suv.png", false));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(13), "clase_g_suv.png", false));
            vehicleModels.Add(new VehicleModel("SUV", "Clase G63", 2025, 0, "NEW", VehiclePageDescriptionHelper.GetContent(14), "clase_g63_suv.png", true));

            // IDs are settled too fast so they repeat. This loop give unique IDs.
            for (int i = 0; i < vehicleModels.Count; i++) vehicleModels[i].Id = vehicleModels[i].Id + i;

            return vehicleModels;
        }
    }
}
