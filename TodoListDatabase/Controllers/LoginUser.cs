using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Database;
using TodoListDatabase.Models;

namespace TodoListDatabase.Controllers
{
    public class LoginUser : ILogin
    {
        public User login(string email, string password)
        {
            User user = null;

            using (var dbContext = new UserDBContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.Email.Trim().ToLower() == email.ToLower() && u.Password.Equals(password));
            }

            if (user != null)
            {
                Temp.user = user;

            }

            return user;
        }
    }
}
