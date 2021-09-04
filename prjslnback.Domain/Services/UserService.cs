using prjslnback.Domain.Entities;
using prjslnback.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace prjslnback.Domain.Services
{
    public class UserService : IUserService
    {

        private List<User> Users = new List<User>();

        public UserService()
        {
            Users.Add(new User { Id = 1, Username = "Usuario1", Password = "Senha1" });
            Users.Add(new User { Id = 2, Username = "Usuario2", Password = "Senha2" });
            Users.Add(new User { Id = 3, Username = "Usuario3", Password = "Senha3" });
        }

        public User FindUser(string username, string password)
        {
            return Users.FirstOrDefault(x => string.Equals(x.Username, username) && string.Equals(x.Password, password));
        }
    }
}
