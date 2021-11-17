using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IServiceOrder
    {
        bool CreateOrder(BLL.Model.ModelOrder order);
        Model.ModelOrder MakeOrder(Model.ModelOrder modelOrder);
        Model.ModelOrder Use_Code(Model.ModelOrder modelOrder, string code);
    }
}
