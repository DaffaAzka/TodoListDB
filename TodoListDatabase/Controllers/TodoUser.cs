using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Database;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Models;

namespace TodoListDatabase.Controllers
{
    public class TodoUser : ITodo
    {
        public bool addTodo(string[] fields)
        {
            using (var dbContext = new TodoDBContext())
            {
                Todo user = new Todo
                {
                    VerifyId = fields[(int)FieldConstants.TODO.VerifyId],
                    Task = fields[(int)FieldConstants.TODO.Task],
                    IsDone = false
                };

                dbContext.Add(user);
                dbContext.SaveChanges();
            }

            return true;
        }

        public bool changeTodo(int id, string task)
        {
            using (var dbContext = new TodoDBContext())
            {
                var result = dbContext.Todos.SingleOrDefault(b => b.Id == id);
                if (result != null)
                {
                    result.Task = task;
                    dbContext.SaveChanges();
                }
            }

            return true;
        }

        public bool getAllTodo()
        {
            using(var dbContext = new TodoDBContext())
            {
                var list = from b in dbContext.Todos
                           where b.VerifyId == Temp.user.VeridyId
                           select b;

                Temp.tasks = list.ToList();
            }

            return true;
        }

        public bool isDoneTodo(int id)
        {
            using (var dbContext = new TodoDBContext())
            {
                var result = dbContext.Todos.SingleOrDefault(b => b.Id == id);
                if (result != null)
                {
                    result.IsDone = true;
                    dbContext.SaveChanges();
                }
            }

            return true;
        }

        public bool taskExist(string task)
        {
            bool exist = false;

            using (var dbContext = new TodoDBContext())
            {
                exist = dbContext.Todos.Any(u => u.Task.ToLower() == task.ToLower());
            }

            return exist;
        }
    }
}
