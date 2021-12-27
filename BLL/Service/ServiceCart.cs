using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Model;

namespace BLL.Service
{
    public class ServiceCart : IServiceCart
    {
        private ModelBasket basket;

        public ServiceCart(ModelBasket basket) => this.basket = basket;

        public void AddTechnic(ModelTechnic technic, int count) => basket.Add(technic, count);

        public void DeleteTechnic(ModelTechnic technic) => basket.Delete(technic);

        public List<ModelLineOrder> line() => basket.List();
    }
}
