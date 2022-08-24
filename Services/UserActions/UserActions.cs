using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserActions
{
    public class UserActions : IUserActions
    {
        private MaravilContext userContext;
        public UserActions(MaravilContext context)
        {
            userContext = context;
        }
        public string MessageText()
        {
            return "Hola Maravil";
        }
    }
}
