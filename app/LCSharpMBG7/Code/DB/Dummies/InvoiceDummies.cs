using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.DB.Dummies
{
    public class InvoiceDummies
    {
        public static List<InvoiceModel> CreateInvoices()
        {
            List<InvoiceModel> invoices = new List<InvoiceModel>();

            if (State.sells == null || State.sells.Count == 0)
            {
                throw new InvalidOperationException("Sells must be initialized and contain at least one SellModel before creating invoices.");
            }

            Random random = new Random();

            for (int i = 0; i < 60; i++)
            {
                // Get a Sell id.
                string idSell = State.sells[i % State.sells.Count].Id;

                // Random invoice price.
                int sellPrice = random.Next(500000, 8000001);

                // Generate random time for the invoice creation. Ranged 3 years before current time.
                long currentUnixTime = DateFormatter.GetUNIXTimestamp();
                long threeYearsInMs = 3L * 365 * 24 * 60 * 60 * 1000; // 3 years * days * hours * minutes * seconds * ms
                long randomOffset = (long)(random.NextDouble() * threeYearsInMs);
                long randomDate = currentUnixTime - randomOffset;
                string dateInvoice = randomDate.ToString();

                // Create and add InvoiceModel
                InvoiceModel invoice = new InvoiceModel(idSell, sellPrice, dateInvoice);
                invoices.Add(invoice);
            }

            return invoices;
        }
    }
}
