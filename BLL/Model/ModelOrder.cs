using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelOrder
    {
        public int id_order { get; set; }
        public DateTime complition_date { get; set; }

        public decimal cost { get; set; }

        public DateTime registration_date { get; set; }

        public int id_state { get; set; }

        public int id_client { get; set; }

        public int? id_code { get; set; }
        public List<int> line;
        public List<int> quant;
        public ModelOrder() { }
        public ModelOrder(DAL.Order order)
        {
            this.complition_date = order.complition_date;
            this.cost = order.cost;
            this.id_client = order.id_client;
            this.id_code = order.id_code;
            this.id_order = order.id_order;
            this.id_state = order.id_state;
            this.registration_date = order.registration_date;
            this.line = order.LineOrder.Select(i => i.id_line).ToList();
            this.quant = order.LineOrder.Select(i => i.quantity).ToList();
        }
    }
}
