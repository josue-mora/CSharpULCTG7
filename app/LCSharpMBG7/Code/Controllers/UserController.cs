using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;

namespace LCSharpMBG7.Code.Controllers
{
    // Controlador que maneja las operaciones relacionadas con usuarios
    public class UserController
    {
        // Carga usuarios ficticios desde datos dummy
        public void LoadDummyUsers()
        {
            List<UserModel> userModels = UserDBDummies.CreateUsers();
            State.users = userModels;
        }

        // Carga usuarios de forma asíncrona desde Firebase
        public async Task LoadUsersFromFirebaseAsync()
        {
            var firebaseHelper = new FirebaseHelper();
            try
            {
                // Obtiene la lista de usuarios desde Firebase
                List<UserModel> users = await firebaseHelper.GetAllUsersAsync();
                State.users = users;
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la carga
                System.Diagnostics.Debug.WriteLine("Error retrieving users from Firebase: " + ex.Message);
            }
        }

        // Método combinado que carga usuarios según la fuente de datos configurada
        public async Task LoadUsersAsync()
        {
            // DATA_SOURCE == 0: Carga solo usuarios dummy
            if (State.DATA_SOURCE == 0)
            {
                LoadDummyUsers();
            }
            // DATA_SOURCE == 1: Carga solo usuarios de Firebase
            else if (State.DATA_SOURCE == 1)
            {
                await LoadUsersFromFirebaseAsync();
            }
            // DATA_SOURCE == 2: Carga ambos, primero dummy y luego Firebase
            else if (State.DATA_SOURCE == 2)
            {
                LoadDummyUsers();
                await LoadUsersFromFirebaseAsync();
            }
        }
    }
}
