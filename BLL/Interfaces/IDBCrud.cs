using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDBCrud
    {

        List<BLL.Model.ModelCategory> ModelCategorys { get; }

        List<BLL.Model.ModelClient> ModelClients { get; }
        List<BLL.Model.ModelLineOrder> LineOrders { get; }

        List<BLL.Model.ModelOrder> ModelOrders { get; }

        List<BLL.Model.ModelPromoCode> ModelPromoCodes { get; }

        List<BLL.Model.ModelState> ModelStates { get; }

        List<BLL.Model.ModelTechnic> ModelTechnics { get; }

        void Create(BLL.Model.ModelCategory model);
        void Create(BLL.Model.ModelClient model);
        void Create(BLL.Model.ModelLineOrder model);
        void Create(BLL.Model.ModelOrder model);
        void Create(BLL.Model.ModelPromoCode model);
        void Create(BLL.Model.ModelState model);
        void Create(BLL.Model.ModelTechnic model);

        void Update(BLL.Model.ModelCategory model);
        void Update(BLL.Model.ModelClient model);
        void Update(BLL.Model.ModelLineOrder model);
        void Update(BLL.Model.ModelOrder model);
        void Update(BLL.Model.ModelPromoCode model);
        void Update(BLL.Model.ModelState model);
        void Update(BLL.Model.ModelTechnic model);

        void Delete(BLL.Model.ModelCategory model);
        void Delete(BLL.Model.ModelClient model);
        void Delete(BLL.Model.ModelLineOrder model);
        void Delete(BLL.Model.ModelOrder model);
        void Delete(BLL.Model.ModelPromoCode model);
        void Delete(BLL.Model.ModelState model);
        void Delete(BLL.Model.ModelTechnic model);
        bool Save();
    }
}
