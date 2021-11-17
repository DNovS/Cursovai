using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IServiceOrder
    {
        bool CreateOrder(BLL.Model.ModelOrder order, string code);
    }
}
