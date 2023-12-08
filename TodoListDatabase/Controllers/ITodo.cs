using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Controllers
{
    public interface ITodo
    {
        public bool getAllTodo();
        public bool addTodo(string[] fields);
        public bool changeTodo(int id, string task);
        public bool isDoneTodo(int id);
        public bool taskExist(string task);
    }
}
