using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Services;
using Firebase.Database.Query;

namespace LCSharpMBG7.Code.Controllers
{
    public class InvoiceController
    {
        private static void LoadDummyInvoices()
        {
            List<InvoiceModel> invoiceModels = InvoiceDummies.CreateInvoices();
            State.invoices = invoiceModels;
        }

        private static async Task LoadInvoicesFromFirebaseAsync()
        {
            try
            {
                List<InvoiceModel> invoices = await GetAllInvoicesAsync();
                State.invoices = invoices;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error retrieving invoices from Firebase: " + ex.Message);
            }
        }

        // Combined method to load invoices based on configured data source
        public static async Task LoadInvoicesAsync()
        {
            if (State.DATA_SOURCE == 0)
            {
                LoadDummyInvoices();
            }
            else if (State.DATA_SOURCE == 1)
            {
                await LoadInvoicesFromFirebaseAsync();
            }
            else if (State.DATA_SOURCE == 2)
            {
                LoadDummyInvoices();
                await LoadInvoicesFromFirebaseAsync();
            }
        }

        // Add a new invoice asynchronously
        public static async Task<string> AddInvoiceAsync(InvoiceModel invoice)
        {
            if (State.DATA_SOURCE == 0)
            {
                State.invoices.Add(invoice);
                return invoice.Id;
            }
            else
            {
                var result = await FirebaseHelper.CreateConnection()
                    .Child("Invoices")
                    .PostAsync(invoice);

                invoice.Id = result.Key;
                State.invoices.Add(invoice);

                await FirebaseHelper.CreateConnection()
                    .Child("Invoices")
                    .Child(result.Key)
                    .PutAsync(invoice);

                return result.Key;
            }
        }

        // Get all invoices asynchronously from Firebase
        public static async Task<List<InvoiceModel>> GetAllInvoicesAsync()
        {
            return (await FirebaseHelper.CreateConnection()
                .Child("Invoices")
                .OnceAsync<InvoiceModel>())
                .Select(item => item.Object)
                .ToList();
        }

        // Update an existing invoice asynchronously
        public static async Task UpdateInvoiceAsync(string key, InvoiceModel invoice)
        {
            for (int i = 0; i < State.invoices.Count; i++)
            {
                if (State.invoices[i].Id == key)
                {
                    State.invoices[i] = invoice;
                    break;
                }
            }

            if (State.DATA_SOURCE == 1)
            {
                await FirebaseHelper.CreateConnection()
                    .Child("Invoices")
                    .Child(key)
                    .PutAsync(invoice);
            }
        }

        // Delete an invoice asynchronously
        public static async Task DeleteInvoiceAsync(string key)
        {
            for (int i = State.invoices.Count - 1; i >= 0; i--)
            {
                if (State.invoices[i].Id == key)
                {
                    State.invoices.RemoveAt(i);
                    break;
                }
            }

            if (State.DATA_SOURCE == 1)
            {
                await FirebaseHelper.CreateConnection()
                    .Child("Invoices")
                    .Child(key)
                    .DeleteAsync();
            }
        }
    }
}
