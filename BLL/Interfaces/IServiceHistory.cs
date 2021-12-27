using BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IServiceHistory
    {
        List<Model.ModelOrder> orders();
        List<ModelTechnic> technics(ModelOrder order);
        void cancel(ModelOrder order);
    }
}
