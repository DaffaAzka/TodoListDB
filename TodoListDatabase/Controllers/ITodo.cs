using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Controllers
{
    public interface ITodo
    {
        bool getAllTodo();
        bool addTodo(string[] fields);
        bool changeTodo(int id, string task);
        bool isDoneTodo(int id);
        bool taskExist(string task);
    }
}
