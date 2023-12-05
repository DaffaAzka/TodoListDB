using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Controllers
{
    public interface ITodo
    {

        bool todo(string[] fields);
        bool taskExist(string email);
    }
}
