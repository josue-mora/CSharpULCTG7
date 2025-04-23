using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;
using Firebase.Database.Query;

namespace LCSharpMBG7.Code.Controllers
{
    public class ReservationController
    {
        // Seed dummy once
        private static void LoadDummyReservations()
        {
            State.reservations = ReservationDummies.CreateReservations();
        }

        // Load from Firebase
        private static async Task LoadReservationsFromFirebaseAsync()
        {
            var list = await FirebaseHelper.CreateConnection()
                .Child("Reservations")
                .OnceAsync<ReservationModel>();
            State.reservations = list.Select(x => x.Object).ToList();
        }

        // Master loader
        public static async Task LoadReservationsAsync()
        {
            if (State.DATA_SOURCE == 0)
            {
                if (State.reservations == null || State.reservations.Count == 0)
                    LoadDummyReservations();
            }
            else if (State.DATA_SOURCE == 1)
            {
                await LoadReservationsFromFirebaseAsync();
            }
            else // 2 = both
            {
                if (State.reservations == null || State.reservations.Count == 0)
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

            var result = await FirebaseHelper.CreateConnection()
                .Child("Reservations")
                .PostAsync(reservation);
            reservation.Id = result.Key;
            State.reservations.Add(reservation);
            await FirebaseHelper.CreateConnection()
                .Child("Reservations")
                .Child(result.Key)
                .PutAsync(reservation);
            return result.Key;
        }

        public static async Task UpdateReservationAsync(string key, ReservationModel reservation)
        {
            var idx = State.reservations.FindIndex(r => r.Id == key);
            if (idx >= 0) State.reservations[idx] = reservation;

            if (State.DATA_SOURCE != 0)
                await FirebaseHelper.CreateConnection()
                    .Child("Reservations")
                    .Child(key)
                    .PutAsync(reservation);
        }

        public static async Task DeleteReservationAsync(string key)
        {
            var idx = State.reservations.FindIndex(r => r.Id == key);
            if (idx >= 0) State.reservations.RemoveAt(idx);

            if (State.DATA_SOURCE != 0)
                await FirebaseHelper.CreateConnection()
                    .Child("Reservations")
                    .Child(key)
                    .DeleteAsync();
        }

        public static async Task<ReservationModel> GetReservationAsync(string key)
            => await FirebaseHelper.CreateConnection()
                .Child("Reservations")
                .Child(key)
                .OnceSingleAsync<ReservationModel>();
    }
}
