using Firebase.Database;
using Firebase.Database.Query;
using LCSharpMBG7.Code.Models;


namespace LCSharpMBG7.Code.Services
{
    public class FirebaseHelper
    {

        // Returns a firebase variable capable of making HTTP
        // requests to the database.
        public static FirebaseClient CreateConnection()
        {
            FirebaseClient firebase = new FirebaseClient("https://mercedesshowroom-679f7-default-rtdb.firebaseio.com/");
            return firebase;
        }
    }
}
