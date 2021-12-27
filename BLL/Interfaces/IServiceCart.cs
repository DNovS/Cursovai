using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Model;

namespace BLL.Interfaces
{
    public interface IServiceCart
    {
        void AddTechnic(ModelTechnic technic, int count);
        void DeleteTechnic(ModelTechnic technic);
        List<ModelLineOrder> line();

    }
}
