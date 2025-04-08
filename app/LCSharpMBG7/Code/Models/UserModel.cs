using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    public class UserModel
    {
        private string id;
        private string name;
        private string email;
        private string password;
        private int role;

        // Default anonymous user.
        public UserModel()
        {
            this.SetId()
                .SetName("")
                .SetEmail("")
                .SetPassword("")
                .SetRole(0);
        }

        // Settled user in database or memory.
        public UserModel
        (
            string id,
            string name,
            string email,
            string password,
            int role
        )
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.role = role;
        }

        public string GetId()
        {
            return id;
        }

        public UserModel SetId()
        {
            this.id = "" + DateFormatter.GetUNIXTimestamp();
            return this;
        }
        public string GetName()
        {
            return name;
        }

        public UserModel SetName(string name)
        {
            if (name == "")
            {
                this.name = "Anónimo";
                return this;
            }
            this.name = name;
            return this;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public UserModel SetEmail(string email)
        {
            if (email == "")
            {
                this.email = "annon@mail.com";
                return this;
            }
            this.email = email;
            return this;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public UserModel SetPassword(string password)
        {
            if (password == "")
            {
                this.password = null;
                return this;
            }
            this.password = password;
            return this;
        }

        public int GetRole()
        {
            return this.role;
        }

        public UserModel SetRole(int role)
        {
            if (Constants.USER_ROLES.Contains(role))
            {
                this.role = role;
            }
            else
            {
                Console.WriteLine($"Invalid role '{role}'.");
                this.role = Constants.USER_ROLES[0];
            }
            return this;
        }

        // ------------------------------------------------
        // Utils.
        // ------------------------------------------------
        public override string ToString()
        {
            return $"Usuario. Nombre: {this.name}. Password: {this.password}. Rol: {this.role}";
        }
    }
}
