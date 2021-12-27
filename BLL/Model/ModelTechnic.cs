using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelTechnic
    {
        public int id_technic { get; set; }
        public string specifications { get; set; }
        public string name { get; set; }
        public int quantity_warehouse { get; set; }
        public decimal cost { get; set; }
        public string image { get; set; }

        public int id_category { get; set; }
        public ModelTechnic() { }
        public ModelTechnic (DAL.Technic technic)
        {
            this.cost = technic.cost;
            this.id_category = technic.id_category;
            this.id_technic = technic.id_technic;
            this.image = technic.image;
            this.name = technic.name;
            this.quantity_warehouse = technic.quantity_warehouse;
            this.specifications = technic.specifications;
        }
    }
}
