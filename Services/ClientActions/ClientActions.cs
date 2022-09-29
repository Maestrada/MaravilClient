using BAL.Models;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Services.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClientActions
{
    public class ClientActions : IClientActions
    {
        private MaravilContext clientContext;
        public ClientActions(MaravilContext context)
        {
            clientContext = context;
        }

        public bool CreateClient(Client client)
        {
            client.CreatedOn = DateTime.Now;
            client.ModifiedOn = DateTime.Now;
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

        public List<Client> ListClient(string clientName, string lastName, string phone, int stateId)
        {
            List<Client> returnData = clientContext.Set<Client>()
                                                   .Include(x => x.Town)
                                                   .Include(x => x.Town.State)
                                                   .Include(x => x.CreatedByUser)
                                                   .Include(x => x.ModifiedByUser)
                                                   .ToList();

            if (!string.IsNullOrEmpty(clientName))
                returnData = returnData.Where(x => x.Name.Contains(clientName.Trim())).ToList();
            if (!string.IsNullOrEmpty(lastName))
                returnData = returnData.Where(x => x.LastName.Contains(lastName.Trim())).ToList();
            if (!string.IsNullOrEmpty(phone))
                returnData = returnData.Where(x => x.CellPhone.Contains(phone.Trim()) || x.CellPhone2.Contains(phone.Trim())).ToList();
            if (stateId > 0)
                returnData = returnData.Where(x => x.Town.StateId == stateId).ToList();

            return returnData;
        }

        public bool UpdateClient(Client client)
        {
            bool result = false;
            if (client != null)
            {
                client.ModifiedOn = DateTime.Now;
                clientContext.Clients.Update(client);
                clientContext.SaveChanges();
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
