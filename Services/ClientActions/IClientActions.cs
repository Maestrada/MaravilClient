using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClientActions
{
    public interface IClientActions
    {
        public bool CreateClient(Client Client);
        public bool UpdateClient(Client Client);
        public bool DeleteClient(Client Client);
        public Client? GetClient(int id);
        public IEnumerable<Client> ListClient(string clientName,string lastName,string phone);
    }
}
