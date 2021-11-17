using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelBasket
    {
        List <ModelTechnic> technics;
        public ModelBasket()
        {
            this.technics = new List<ModelTechnic>();
        }
        public void Add(ModelTechnic technic)
        {
            this.technics.Add(technic);
        }
    }
}
