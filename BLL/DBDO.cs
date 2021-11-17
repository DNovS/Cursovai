using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Model;

namespace BLL
{
    public class DBDO : IDBCrud
    {
        private DAL.Interfaces.IRepositoryDB repository;
        public DBDO(DAL.Interfaces.IRepositoryDB repository) => this.repository = repository;

        public void Create(ModelCategory model)
        {
            repository.Categorys.Create(new DAL.Category()
            {
                id_category = model.id_category,
                name = model.name,
            });
        }

        public void Create(ModelClient model)
        {
            repository.Clients.Create(new DAL.Client()
            {
                FCS = model.FCS,
                id_client = model.id_client,
                login = model.login,
                password = model.password,
            });
        }

        public void Create(ModelLineOrder model)
        {
            repository.LineOreders.Create(new DAL.LineOrder()
            {
                cost = model.cost,
                id_line = model.id_line,
                id_order = model.id_order,
                id_technic = model.id_technic,
                quantity = model.quantity,
            });
        }

        public void Create(ModelOrder model)
        {
            repository.Orders.Create(new DAL.Order()
            {
                complition_date = model.complition_date,
                cost = model.cost,
                id_client = model.id_client,
                id_code = model.id_code,
                id_order = model.id_order,
                id_state = model.id_state,
                registration_date = model.registration_date,
            });
        }

        public void Create(ModelPromoCode model)
        {
            repository.PromoCodes.Create(new DAL.PromoCode()
            {
                discount_amount = model.discount_amount,
                id_code = model.id_code,
                name = model.name,
                number_use = model.number_use,
                number_use_start = model.number_use_start,
            });
        }

        public void Create(ModelState model)
        {
            repository.States.Create(new DAL.State()
            {
                id_state = model.id_state,
                name = model.name,
            });
        }

        public void Create(ModelTechnic model)
        {
            repository.Technics.Create(new DAL.Technic()
            {
                cost = model.cost,
                id_category = model.id_category,
                id_technic = model.id_technic,
                image = model.image,
                name = model.name,
                quantity_warehouse = model.quantity_warehouse,
                specifications = model.specifications,
            });
        }

        public void Delete(ModelCategory model)
        {
            DAL.Category category = repository.Categorys.GetItem(model.id_category);
            if (category != null)
            {
                repository.Categorys.Delete(category.id_category);
                Save();
            }
        }

        public void Delete(ModelClient model)
        {
            DAL.Client client = repository.Clients.GetItem(model.id_client);
            if(client != null)
            {
                repository.Clients.Delete(client.id_client);
                Save();
            }
        }

        public void Delete(ModelLineOrder model)
        {
            DAL.LineOrder lineOrder = repository.LineOreders.GetItem(model.id_line);
            if (lineOrder != null)
            {
                repository.LineOreders.Delete(lineOrder.id_line);
                Save();
            }
        }

        public void Delete(ModelOrder model)
        {
            DAL.Order order = repository.Orders.GetItem(model.id_order);
            if(order != null)
            {
                repository.Orders.Delete(order.id_order);
                Save();
            }
        }

        public void Delete(ModelPromoCode model)
        {
            DAL.PromoCode promoCode = repository.PromoCodes.GetItem(model.id_code);
            if (promoCode != null)
            {
                repository.PromoCodes.Delete(promoCode.id_code);
                Save();
            }
        }

        public void Delete(ModelState model)
        {
            DAL.State state = repository.States.GetItem(model.id_state);
            if(state != null)
            {
                repository.States.Delete(state.id_state);
                Save();
            }
        }

        public void Delete(ModelTechnic model)
        {
            DAL.Technic technic = repository.Technics.GetItem(model.id_technic);
            if(technic!=null)
            {
                repository.Technics.Delete(technic.id_technic);
                Save();
            }
        }

        public List<ModelLineOrder> LineOrders => repository.LineOreders.List.Select(i => new ModelLineOrder(i)).ToList();

        public List<ModelCategory> ModelCategorys => repository.Categorys.List.Select(i => new ModelCategory(i)).ToList();

        public List<ModelClient> ModelClients => repository.Clients.List.Select(i => new ModelClient(i)).ToList();

        public List<ModelOrder> ModelOrders => repository.Orders.List.Select(i => new ModelOrder(i)).ToList();

        public List<ModelPromoCode> ModelPromoCodes => repository.PromoCodes.List.Select(i => new ModelPromoCode(i)).ToList();

        public List<ModelState> ModelStates => repository.States.List.Select(i => new ModelState(i)).ToList();

        public List<ModelTechnic> ModelTechnics => repository.Technics.List.Select(i => new ModelTechnic(i)).ToList();

        public bool Save() => repository.Save() > 0;

        public void Update(ModelCategory model)
        {
            DAL.Category category = repository.Categorys.GetItem(model.id_category);
            category.name = model.name;
            Save();
        }

        public void Update(ModelClient model)
        {
            DAL.Client client = repository.Clients.GetItem(model.id_client);
            client.FCS = model.FCS;
            client.login = model.login;
            client.password = model.password;
            Save();
        }

        public void Update(ModelLineOrder model)
        {
            DAL.LineOrder lineOrder = repository.LineOreders.GetItem(model.id_line);
            lineOrder.cost = model.cost;
            lineOrder.id_order = model.id_order;
            lineOrder.id_technic = model.id_technic;
            lineOrder.quantity = model.quantity;
            Save();
        }

        public void Update(ModelOrder model)
        {
            DAL.Order order = repository.Orders.GetItem(model.id_order);
            order.complition_date = model.complition_date;
            order.cost = model.cost;
            order.id_client = model.id_client;
            order.id_code = model.id_code;
            order.id_state = model.id_state;
            order.registration_date = model.registration_date;
            Save();
        }

        public void Update(ModelPromoCode model)
        {
            DAL.PromoCode promoCode = repository.PromoCodes.GetItem(model.id_code);
            promoCode.name = model.name;
            promoCode.number_use = model.number_use;
            promoCode.number_use_start = model.number_use_start;
            promoCode.discount_amount = model.discount_amount;
            Save();
        }

        public void Update(ModelState model)
        {
            DAL.State state = repository.States.GetItem(model.id_state);
            state.name = model.name;
            Save();
        }

        public void Update(ModelTechnic model)
        {
            DAL.Technic technic = repository.Technics.GetItem(model.id_technic);
            technic.id_category = model.id_category;
            technic.image = model.image;
            technic.cost = model.cost;
            technic.name = model.name;
            technic.quantity_warehouse = model.quantity_warehouse;
            technic.specifications = model.specifications;
            Save();
        }
    }
}
