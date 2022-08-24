using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClientActions
{
    public class ClientActions:IClientActions
    {
        private MaravilContext userContext;
        public ClientActions(MaravilContext context)
        {
            userContext = context;
        }

        public string SendGreetings()
        {
            return "Greetings";
        }
    }
}
