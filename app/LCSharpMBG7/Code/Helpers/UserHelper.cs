using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Code.Helpers
{
    // Clase auxiliar para gestionar usuarios
    public class UserHelper
    {
        // Crea un usuario administrador con el rol más alto
        // Parámetros:
        // - name: nombre del usuario
        // - email: correo electrónico del usuario  
        // - password: contraseña del usuario
        public static UserModel CreateAdministratorHighest(string name, string email, string password)
        {
            UserModel userModel = new UserModel();
            
            // Asigna nombre por defecto si está vacío
            userModel.Name = string.IsNullOrWhiteSpace(name) ? "Anónimo" : name;
            // Asigna email por defecto si está vacío
            userModel.Email = string.IsNullOrWhiteSpace(email) ? "annon@mail.com" : email;
            // Para evitar advertencias de referencia nula, asigna cadena vacía en lugar de null
            userModel.Password = string.IsNullOrWhiteSpace(password) ? "" : password;
            // Establece el rol de administrador más alto
            userModel.Role = Constants.USER_ROLES[Constants.USER_ROLES.Length - 1];
            return userModel;
        }

        // Verifica si la contraseña proporcionada coincide con la del usuario
        // Parámetros:
        // - user: modelo de usuario a verificar
        // - password: contraseña a validar
        public static bool IsPasswordCorrect(UserModel user, string password)
        {
            // Valida que ni el usuario ni la contraseña sean nulos
            if (user == null || password == null)
            {
                return false;
            }
            // Compara la contraseña proporcionada con la almacenada
            return user.Password == password;
        }
    }
}
