﻿using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;
using Firebase.Database.Query;

namespace LCSharpMBG7.Code.Controllers
{
    // Controlador que maneja las operaciones relacionadas con usuarios
    public class UserController
    {
        // Carga usuarios ficticios desde datos dummy
        public static void LoadDummyUsers()
        {
            List<UserModel> userModels = UserDBDummies.CreateUsers();
            State.users = userModels;
        }

        // Carga usuarios de forma asíncrona desde Firebase
        public static async Task LoadUsersFromFirebaseAsync()
        {
            try
            {
                // Obtiene la lista de usuarios desde Firebase
                List<UserModel> users = await GetAllUsersAsync();
                State.users = users;
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la carga
                System.Diagnostics.Debug.WriteLine("Error retrieving users from Firebase: " + ex.Message);
            }
        }

        // Método combinado que carga usuarios según la fuente de datos configurada
        public static async Task LoadUsersAsync()
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

        public static async Task<string> AddUserAsync(UserModel user)
        {
            if (State.DATA_SOURCE == 0)
            {
                State.users.Add(user);
                return user.Id;
            }
            // 1
            else
            {
                var result = await FirebaseHelper.CreateConnection()
                .Child("Users")
                .PostAsync(user);
                user.Id = result.Key;
                State.users.Add(user);
                return result.Key;
            }
        }

        public static async Task<List<UserModel>> GetAllUsersAsync()
        {
            return (await FirebaseHelper.CreateConnection()
                .Child("Users")
                .OnceAsync<UserModel>())
                .Select(item => item.Object)
                .ToList();
        }

        public static async Task UpdateUserAsync(string key, UserModel user)
        {
            await FirebaseHelper.CreateConnection()
                .Child("Users")
                .Child(key)
                .PutAsync(user);
        }

        public static async Task DeleteSellAsync(string key)
        {
            await FirebaseHelper.CreateConnection()
                .Child("Sells")
                .Child(key)
                .DeleteAsync();
        }
    }
}
