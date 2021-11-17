using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelCategory
    {
        public int id_category { get; set; }

        public string name { get; set; }

        public ModelCategory() { }
        public ModelCategory(DAL.Category category)
        {
            this.id_category = category.id_category;
            this.name = category.name;
        }
    }
}
