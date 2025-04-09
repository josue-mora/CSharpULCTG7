using LCSharpMBG7.Code.Helpers;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.DB.Dummies
{
    // Clase que contiene datos de prueba para usuarios
    public class UserDBDummies
    {
        // Método que crea una lista de usuarios predefinidos
        public static List<UserModel> CreateUsers()
        {
            // Inicializa una nueva lista vacía de modelos de usuario
            List<UserModel> userModels = new List<UserModel>();
            // Asegúrate que UserHelper.CreateAdministratorHighest esté actualizado
            // para usar el nuevo UserModel con propiedades públicas.
            // Agrega un usuario administrador con máximos privilegios
            userModels.Add(UserHelper.CreateAdministratorHighest("admin", "admin@mail.com", "admin"));
            // Devuelve la lista de usuarios
            return userModels;
        }
    }
}
