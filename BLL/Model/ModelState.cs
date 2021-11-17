using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelState
    {
        public int id_state { get; set; }
        public string name { get; set; }

        public ModelState() { }
        public ModelState(DAL.State state)
        {
            this.id_state = state.id_state;
            this.name = state.name;
        }
    }
}
