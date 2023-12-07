using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.FieldValidators
{
    public static class FieldConstants
    {
        public enum USER {
            Id,
            VeridyId,
            Username,
            Email,
            Password
        }

        public enum TODO
        {
            Id,
            VerifyId,
            Task,
            IsDone
        }

    }
}
