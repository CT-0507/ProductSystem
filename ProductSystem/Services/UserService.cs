using Microsoft.VisualBasic;
using ProductSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductSystem.Services
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>()
        {
            new User() {Username = "abc001", Password = "001", DeleteYMD = null},
            new User() {Username = "abc002", Password = "002", DeleteYMD = DateAndTime.Today},
            new User() {Username = "abc003", Password = "003"}
        };
        public User getUserByUserNameAndPassword(string userName, string password)
        {
            return _users.AsEnumerable()
                    .Where(x => x.Username == userName)
                    .Where(x => password == userName).FirstOrDefault();
        }
    }
}
