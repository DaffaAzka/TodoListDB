using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Controllers
{
    public interface IRegister
    {
        bool register(string[] fields);
        bool emailExist(string email);
        bool usernameExist(string username);
    }
}
