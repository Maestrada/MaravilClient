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

        public List<Client> ListClient(string clientName,string lastName,string phone)
        {
            List<Client> returnData =  new List<Client>() ;

            if (!string.IsNullOrEmpty(clientName) || !string.IsNullOrEmpty(lastName) || !string.IsNullOrEmpty(phone))
            {
                if (!string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(phone))
                    returnData = clientContext.Clients.Where(x => x.Name.Contains(clientName.Trim()) || x.LastName.Contains(lastName.Trim())||x.CellPhone.Contains(phone.Trim())||x.CellPhone2.Contains(phone.Trim())).ToList();
                if (!string.IsNullOrEmpty(clientName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(phone))
                    returnData = clientContext.Clients.Where(x => x.Name.Contains(clientName.Trim())).ToList();
                if (string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(phone))
                    returnData = clientContext.Clients.Where(x => x.LastName.Contains(lastName.Trim())).ToList();
                if (string.IsNullOrEmpty(clientName) && string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(phone))
                    returnData = clientContext.Clients.Where(x => x.CellPhone.Contains(phone.Trim()) || x.CellPhone2.Contains(phone.Trim())).ToList();
            }
            else
            {
                returnData = clientContext.Clients.ToList();
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
