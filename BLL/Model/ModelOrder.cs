using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelOrder
    {
        #region
        public string fcs { get; set; }
        public string color { get; set; }
        public string date_com { get; set; }
        public string date_reg { get; set; }
        public string cancel_visibal { get; set; }
        #endregion
        public string code { get; set; }
        public int id_order { get; set; }
        public DateTime registration_date { get; set; }
        public DateTime complition_date { get; set; }

        public decimal cost { get; set; }

        public int id_state { get; set; }

        public int id_client { get; set; }

        public int? id_code { get; set; }
        public List<ModelLineOrder> lineOrders { get; set; }
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
            this.lineOrders = order.LineOrder.Select(i => new Model.ModelLineOrder(i)).ToList();
            this.fcs = order.Client.FCS;
            this.date_com = complition_date == DateTime.MinValue ? "\"не определено\"" : complition_date.ToString();
            this.date_reg = registration_date == DateTime.MinValue ? "\"не определено\"" : registration_date.ToString();
            this.cancel_visibal = id_state != 1 ? "Hidden" : "Visible"; 
            switch (order.id_state)
            {
                case 1:
                    color = "Yellow";
                    break;
                case 2:
                    color = "Green";
                    break;
                case 3:
                    color = "Red";
                    break;
                default:
                    break;
            }
        }
    }
}
