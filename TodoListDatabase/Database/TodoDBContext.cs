using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Database
{
    internal class TodoDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}Todo.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Models.Todo> Todos { get; set; }
    }
}
