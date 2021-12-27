using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelBasket
    {
        private List<ModelLineOrder> line;
        public ModelBasket()
        {
            this.line = new List<ModelLineOrder>();
        }
        public void Add(ModelTechnic technic, int count) => this.line.Add(new ModelLineOrder 
        { 
            id_technic = technic.id_technic, 
            quantity = count, 
            cost = count * technic.cost 
        });

        public void Delete(ModelTechnic technic) => this.line.Remove(line.Find(i => i.id_technic == technic.id_technic));

        public List<ModelLineOrder> List () => line;
    }
}
