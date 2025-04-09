using Newtonsoft.Json;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    // Modelo de usuario que representa la información almacenada en Firebase
    public class UserModel
    {
        // Propiedades públicas para la serialización en Firebase
        [JsonProperty("id")]
        public string Id { get; set; }
        
        // Nombre del usuario
        [JsonProperty("name")] 
        public string Name { get; set; }
        
        // Correo electrónico del usuario
        [JsonProperty("email")]
        public string Email { get; set; }
        
        // Contraseña del usuario (puede ser nula)
        [JsonProperty("password")]
        public string Password { get; set; }
        
        // Rol/nivel de acceso del usuario (número entero)
        [JsonProperty("role")]
        public int Role { get; set; }

        // Constructor por defecto - crea un usuario anónimo
        public UserModel()
        {
            // Genera el ID usando la marca de tiempo UNIX
            this.Id = DateFormatter.GetUNIXTimestamp().ToString();
            
            // Establece valores predeterminados
            this.Name = "Anónimo";
            this.Email = "annon@mail.com";
            this.Password = null;
            this.SetRole(0);
        }

        // Constructor para usuario existente - inicializa con datos de la base de datos o memoria
        public UserModel(string id, string name, string email, string password, int role)
        {
            this.Id = id;
            this.Name = string.IsNullOrWhiteSpace(name) ? "Anónimo" : name;
            this.Email = string.IsNullOrWhiteSpace(email) ? "annon@mail.com" : email;
            this.Password = string.IsNullOrWhiteSpace(password) ? null : password;
            this.SetRole(role);
        }

        // Método privado para validar y establecer el rol del usuario
        private void SetRole(int role)
        {
            if (Constants.USER_ROLES.Contains(role))
            {
                this.Role = role;
            }
            else
            {
                Console.WriteLine($"Invalid role '{role}'.");
                this.Role = Constants.USER_ROLES[0];
            }
        }

        // Sobrescribe el método ToString para mostrar información del usuario
        public override string ToString()
        {
            return $"Usuario. Nombre: {this.Name}. Password: {this.Password}. Rol: {this.Role}";
        }
    }
}
