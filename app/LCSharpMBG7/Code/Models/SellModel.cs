using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Models
{
    public class SellModel
    {

        private string id;
        private string date_sell;
        private string buyer_id_card_number;
        private string buyer_name;

        public SellModel() { }

        public SellModel
        (
            string date_sell,
            string buyer_id_card_number,
            string buyer_name
        )
        {
            this.SetId()
                .SetDateSell(date_sell)
                .SetBuyerIdCardNumber(buyer_id_card_number)
                .SetBuyerName(buyer_name);
        }

        // ================================================
        // Get and Set.
        // ================================================

        public string GetId()
        {
            return id;
        }

        public SellModel SetId()
        {
            this.id = "" + DateFormatter.GetUNIXTimestamp();
            return this;
        }

        public string GetDateSell()
        {
            return date_sell;
        }

        public SellModel SetDateSell(string date)
        {
            if (!string.IsNullOrWhiteSpace(date) && date.Length >= 8)
            {
                this.date_sell = date;
            }
            else
            {
                this.date_sell = "" + DateFormatter.GetUNIXTimestamp();
            }
            return this;
        }

        public string GetBuyerIdCardNumber()
        {
            return buyer_id_card_number;
        }

        public SellModel SetBuyerIdCardNumber(string buyer_id_card_number)
        {
            if (!string.IsNullOrWhiteSpace(buyer_id_card_number) &&
                buyer_id_card_number.All(char.IsDigit))
            {
                this.buyer_id_card_number = buyer_id_card_number.Trim();
            }
            else
            {
                this.buyer_id_card_number = "1-2222-3333";
            }
            return this;
        }

        public string GetBuyerName()
        {
            return buyer_name;
        }

        public SellModel SetBuyerName(string buyer_name)
        {
            // "Xi" is a Chinese name, so 2 as length is valid.
            if (!string.IsNullOrWhiteSpace(buyer_name) && buyer_name.Trim().Length > 1)
            {
                this.buyer_name = buyer_name.Trim();
            }
            else
            {
                this.buyer_name = "Pepe";
            }
            return this;
        }

    }
}
