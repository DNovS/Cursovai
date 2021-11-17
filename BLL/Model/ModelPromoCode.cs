using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelPromoCode
    {
        public int id_code { get; set; }

        public string name { get; set; }

        public int? number_use { get; set; }

        public int? number_use_start { get; set; }

        public int discount_amount { get; set; }

        public ModelPromoCode() { }
        public ModelPromoCode (DAL.PromoCode promoCode)
        {
            this.discount_amount = promoCode.discount_amount;
            this.id_code = promoCode.id_code;
            this.name = promoCode.name;
            this.number_use = promoCode.number_use;
            this.number_use_start = promoCode.number_use_start;
        }
        public decimal Check(decimal s)
        {
            if (number_use > 0)
            {
                number_use--;
                return s * (1 - discount_amount);
            }
            else return s;
        }
    }
}
