using BAL.Models;
using DAL.DataContext;
using Services.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public bool CreateUser(User user)
        {      
            IEnumerable<User> listUser = (IEnumerable<User>)userContext.Users.Select(x => x.UserName == user.UserName.Trim());

            //UserNAme is being Used
            if (listUser != null && listUser.Any(x => x.UserName == user.UserName.Trim()))
            {
                throw new Exception("Usuario ya en uso");
            }
            user.Password = Encrypt.GetSHA256(user.Password);
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            userContext.Add(user);
            userContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(User user)
        {
            bool result = false;
            User userToDelete = GetUser(user.Id);
            if (userToDelete != null)
            {
                userContext.Remove(userToDelete);
                userContext.SaveChanges();
                result = true;
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
            return result;
        }

        public User? GetUser(int id)
        {
            return userContext.Users.Find(id);
        }

        public IEnumerable<User> ListUser(string userName)
        {
            return (userName == null && userName != String.Empty) ? (IEnumerable<User>)userContext.Users.Select(x => x.UserName.Contains(userName.Trim())) : (IEnumerable<User>)userContext.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            IEnumerable<User> listUser = (IEnumerable<User>)userContext.Users.Select(x => x.UserName == user.UserName.Trim());

            //UserNAme is being Used
            if (listUser != null && listUser.Any(x => x.Id != user.Id))
            {
                throw new Exception("Usuario ya en uso");
            }

            User? userToUpdate = GetUser(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.ModifiedOn = DateTime.Now;
                userToUpdate.UserName = user.UserName;
                userToUpdate.Password = Encrypt.GetSHA256(user.Password);
                result = true;
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
            return result;
        }
    }
}
