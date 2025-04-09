using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;

namespace LCSharpMBG7.Code.Controllers
{
    // Controlador para gestionar las ventas
    public class SellController
    {
        // Carga datos de ventas ficticios desde la fuente de datos dummy
        public static void LoadDummySells()
        {
            List<SellModel> sellModels = SellDummies.CreateSells();
            State.sells = sellModels;
        }

        // Carga de manera asíncrona las ventas desde Firebase
        public async Task LoadSellsFromFirebaseAsync()
        {
            var firebaseHelper = new FirebaseHelper();
            try
            {
                // Obtiene todas las ventas de Firebase y las almacena en el estado
                List<SellModel> sells = await firebaseHelper.GetAllSellsAsync();
                State.sells = sells;
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la carga desde Firebase
                System.Diagnostics.Debug.WriteLine("Error retrieving sells from Firebase: " + ex.Message);
            }
        }

        // Método combinado que carga ventas según la fuente de datos configurada
        public async Task LoadSellsAsync()
        {
            // DATA_SOURCE == 0: Carga solo datos dummy
            if (State.DATA_SOURCE == 0)
            {
                LoadDummySells();
            }
            // DATA_SOURCE == 1: Carga solo datos de Firebase
            else if (State.DATA_SOURCE == 1)
            {
                await LoadSellsFromFirebaseAsync();
            }
            // DATA_SOURCE == 2: Carga tanto datos dummy como de Firebase
            else if (State.DATA_SOURCE == 2)
            {
                LoadDummySells();
                await LoadSellsFromFirebaseAsync();
            }
        }
    }
}

