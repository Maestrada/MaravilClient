using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserActions
{
    public interface IUserActions
    {
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public User? GetUser(int id);
        public IEnumerable<User> ListUser(string userName);
       
    }
}
