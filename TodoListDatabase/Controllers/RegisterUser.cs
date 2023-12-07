using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Database;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Models;

namespace TodoListDatabase.Controllers
{
    public class RegisterUser : IRegister
    {
        public bool emailExist(string email)
        {
            bool exist = false;

            using (var dbContext = new UserDBContext())
            {
                exist = dbContext.Users.Any(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
            }
            return exist;
        }

        public bool register(string[] fields)
        {
            using (var dbContext = new UserDBContext())
            {
                User user = new User
                {
                    VeridyId = fields[(int)FieldConstants.USER.VeridyId],
                    Username = fields[(int)FieldConstants.USER.Username],
                    Email = fields[(int)FieldConstants.USER.Email],
                    Password = fields[(int)FieldConstants.USER.Password],
                };

                dbContext.Add(user);
                dbContext.SaveChanges();
            }

            return true;
        }

        public bool usernameExist(string username)
        {
            bool exist = false;

            using (var dbContext = new UserDBContext())
            {
                exist = dbContext.Users.Any(u => u.Username.ToLower() == username.ToLower());
            }

            return exist;
        }
    }
}
