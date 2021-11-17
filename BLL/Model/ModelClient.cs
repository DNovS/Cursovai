using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class ModelClient
    {
        public int id_client { get; set; } 
        public string login { get; set; }
        public string password { get; set; } 
        public string FCS { get; set; }

        public ModelClient() { }
        public ModelClient(DAL.Client client)
        {
            this.FCS = client.FCS;
            this.id_client = client.id_client;
            this.login = client.login;
            this.password = client.password;
        }

    }
}
