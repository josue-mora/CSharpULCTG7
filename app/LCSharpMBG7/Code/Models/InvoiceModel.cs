using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Validators;
using System.Diagnostics;

namespace LCSharpMBG7.Code.Models
{
    public class InvoiceModel
    {
        public string Id;
        public string IdSell;
        public int SellPrice;
        public string DateInvoice;

        public InvoiceModel(string idSell, int sellPrice, string dateInvoice)
        {
            // Id.
            this.Id = DateFormatter.GetUNIXTimestamp().ToString();
            // Validates Sell id.
            bool _sell_exists = false;
            for (int i = 0; i < State.sells.Count; i++)
            {
                if (State.sells[i].Id == idSell)
                {
                    _sell_exists = true;
                    break;
                }
            }
            if (_sell_exists == true)
            {
                this.IdSell = idSell;
            }
            else
            {
                Debug.WriteLine($"Relationship between Invoice and Sell error. Sell ID {idSell} does not exist in existing Sells.");
                this.IdSell = State.sells.First().Id;
            }
            // SellPrice.
            if (sellPrice <= 0)
            {
                this.SellPrice = 5000000;
            }
            else
            {
                this.SellPrice = sellPrice;
            }
            // DateInvoice.
            if (UnixTimeValidator.IsValidUnixTimeMilliseconds(dateInvoice) == true)
                this.DateInvoice = dateInvoice;
            else
                this.DateInvoice = "" + DateFormatter.GetUNIXTimestamp();
        }

        public override string ToString()
        {
            return $"Invoice. ID: {this.Id}. ID venta: {this.IdSell}. Fecha invoice cruda: {this.DateInvoice}. Fecha invoice con formato: {DateFormatter.FormatUNIXToDate(this.DateInvoice)}. Precio de venta: {this.SellPrice}";
        }
    }
}
