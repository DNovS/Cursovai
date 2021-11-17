using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelLineOrder
    {
        public int id_line { get; set; }

        public int id_order { get; set; }

        public int id_technic { get; set; }

        public int quantity { get; set; }

        public decimal cost { get; set; }
        public ModelLineOrder() {}
        public ModelLineOrder(DAL.LineOrder lineOrder)
        {
            this.id_line = lineOrder.id_line;
            this.id_order = lineOrder.id_order;
            this.id_technic = lineOrder.id_technic;
            this.quantity = lineOrder.quantity;
            this.cost = lineOrder.cost;
        }
    }
}
