﻿using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;
using Firebase.Database.Query;

namespace LCSharpMBG7.Code.Controllers
{
    // Controlador que maneja las operaciones relacionadas con reservaciones
    public class ReservationController
    {
        // Carga reservaciones ficticias desde datos de prueba
        private static void LoadDummyReservations()
        {
            List<ReservationModel> models = ReservationDummies.CreateReservations();
            State.reservations = models;
        }

        // Carga de manera asíncrona las reservaciones desde Firebase
        private static async Task LoadReservationsFromFirebaseAsync()
        {
            try
            {
                // Obtiene todas las reservaciones de Firebase y las almacena en el estado
                List<ReservationModel> reservations = await GetAllReservationsAsync();
                State.reservations = reservations;
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la carga desde Firebase
                System.Diagnostics.Debug.WriteLine("Error al recuperar reservaciones de Firebase: " + ex.Message);
            }
        }

        // Método combinado de carga basado en la configuración de DATA_SOURCE
        public static async Task LoadReservationsAsync()
        {
            // Si DATA_SOURCE es 0, carga solo datos ficticios
            if (State.DATA_SOURCE == 0)
            {
                LoadDummyReservations();
            }
            // Si DATA_SOURCE es 1, carga solo datos de Firebase
            else if (State.DATA_SOURCE == 1)
            {
                await LoadReservationsFromFirebaseAsync();
            }
            // Si DATA_SOURCE es 2, carga ambos: primero los datos ficticios y luego los de Firebase
            else if (State.DATA_SOURCE == 2)
            {
                // Carga opcional de ambas fuentes: primero los datos ficticios y luego fusiona o sobrescribe con datos de Firebase
                LoadDummyReservations();
                await LoadReservationsFromFirebaseAsync();
            }
        }

        public static async Task<string> AddReservationAsync(ReservationModel reservation)
        {
            if (State.DATA_SOURCE == 0)
            {
                State.reservations.Add(reservation);
                return reservation.Id;
            }
            // 1
            else
            {
                // Post object on db.
                var result = await FirebaseHelper.CreateConnection()
                    .Child("Reservations")
                    .PostAsync(reservation);
                // Saves unique Firebase key in Id property and memory.
                reservation.Id = result.Key;
                State.reservations.Add(reservation);
                // Updates Id property in object saved on the DB.
                await FirebaseHelper.CreateConnection()
                    .Child("Reservations")
                    .Child(result.Key)
                    .PutAsync(reservation);
                return result.Key;
            }
        }

        public static async Task<List<ReservationModel>> GetAllReservationsAsync()
        {
            return (await FirebaseHelper.CreateConnection()
                .Child("Reservations")
                .OnceAsync<ReservationModel>())
                .Select(item => item.Object)
                .ToList();
        }

        public static async Task<ReservationModel> GetReservationAsync(string key)
        {
            return await FirebaseHelper.CreateConnection()
                .Child("Reservations")
                .Child(key)
                .OnceSingleAsync<ReservationModel>();
        }

        public static async Task UpdateReservationAsync(string key, ReservationModel reservation)
        {
            for (int i = 0; i < State.reservations.Count; i++)
            {
                if (State.reservations[i].Id == key)
                {
                    State.reservations[i] = reservation;
                    break;
                }
            }
            if (State.DATA_SOURCE == 1)
            {
                await FirebaseHelper.CreateConnection()
                    .Child("Reservations")
                    .Child(key)
                    .PutAsync(reservation);
            }
        }

        public static async Task DeleteReservationAsync(string key)
        {
            for (int i = State.reservations.Count - 1; i >= 0; i--)
            {
                if (State.reservations[i].Id == key)
                {
                    State.reservations.RemoveAt(i);
                    break;
                }
            }
            if (State.DATA_SOURCE == 1)
            {
                await FirebaseHelper.CreateConnection()
                    .Child("Reservations")
                    .Child(key)
                    .DeleteAsync();
            }
        }
    }
}

