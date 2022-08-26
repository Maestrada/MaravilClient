using BAL.Models;
using DAL.DataContext;
using Services.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClientActions
{
    public class ClientActions:IClientActions
    {
        private MaravilContext clientContext;
        public ClientActions(MaravilContext context)
        {
            clientContext = context;
        }

        public bool CreateClient(Client client)
        {
            client.CreatedOn = DateTime.Now;
            client.ModifiedOn  = DateTime.Now;
            client.CreatedByUserId = 1;
            client.ModifiedByUserId = 1;
            clientContext.Add(client);
            clientContext.SaveChanges();
            return true;
        }

        public bool DeleteClient(Client client)
        {
            bool result = false;
            Client clientToDelete = GetClient(client.Id);
            if (clientToDelete != null)
            {
                clientContext.Remove(clientToDelete);
                clientContext.SaveChanges();
                result = true;
            }
            else
            {
                throw new Exception("Cliente no encontrado");
            }
            return result;
        }

        public Client? GetClient(int id)
        {
            return clientContext.Clients.Find(id);
        }

        public IEnumerable<Client> ListClient(string clientName,string lastName)
        {
            IEnumerable<Client> returnData =  new List<Client>() ;

            if (!string.IsNullOrEmpty(clientName) || !string.IsNullOrEmpty(lastName)) {
                if (!string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(lastName))
                    returnData = (IEnumerable<Client>)clientContext.Clients.Select(x => x.Name.Contains(clientName.Trim()) || x.LastName.Contains(lastName.Trim()));
                if (!string.IsNullOrEmpty(clientName) && string.IsNullOrEmpty(lastName))
                    returnData = (IEnumerable<Client>)clientContext.Clients.Select(x => x.Name.Contains(clientName.Trim()));
                if (string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(lastName))
                    returnData = (IEnumerable<Client>)clientContext.Clients.Select(x => x.LastName.Contains(lastName.Trim()));
            }
            else
            {
                returnData = (IEnumerable<Client>)clientContext.Clients.ToList();
            }

            return returnData;
        }

        public bool UpdateClient(Client client)
        {
            bool result = false;          

            Client? userToUpdate = GetClient(client.Id);
            if (userToUpdate != null)
            {
                userToUpdate.ModifiedOn = DateTime.Now;
                userToUpdate.ModifiedByUserId = 2;
                result = true;
            }
            else
            {
                throw new Exception("Cliente no encontrado");
            }
            return result;
        }
    }
}
