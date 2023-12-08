using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.FieldValidators;

namespace TodoListDatabase.Views
{
    public interface IViews
    {
        void RunView();
        IFieldValidator FieldValidator { get; }
    }
}
