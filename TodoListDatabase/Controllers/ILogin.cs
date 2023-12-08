using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Models;

namespace TodoListDatabase.Controllers
{
    public interface ILogin
    {
        User login(string email, string password);
    }
}
