using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Controllers
{
    public interface ITodo
    {

        bool addTodo(string[] fields);
        bool changeTodo(int id);
        bool isDoneTodo(int id);
        bool removeTodo(int id);
        bool taskExist(string email);
    }
}
