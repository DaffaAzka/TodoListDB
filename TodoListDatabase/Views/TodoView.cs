﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Controllers;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Models;
using TodoListDatabase.Utilities;

namespace TodoListDatabase.Views
{
    public class TodoView : IViews
    {
        IFieldValidator _fieldValidator = null;
        ITodo _todo = null;
        Todo[] isDone = null;
        Todo[] isNot = null;

        private void selectedTodo()
        {
            List<Todo> done = new List<Todo>();
            List<Todo> not = new List<Todo>();

            for (int i = 0; i < Temp.tasks.Length; i++)
            {
                if (Temp.tasks[i].IsDone)
                {
                    done.Add(Temp.tasks[i]);
                }
                else
                {
                    not.Add(Temp.tasks[i]);
                }
            }

            isDone = done.ToArray();
            isNot = not.ToArray();
        }

        public TodoView(IFieldValidator fieldValidator, ITodo todo)
        {
            _fieldValidator = fieldValidator;
            _todo = todo;
        }

        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public void RunView()
        {
            _todo.getAllTodo();
            selectedTodo();

            CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
            Console.WriteLine($"Welcome on the app {Temp.user.Username}!");
            CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

            Console.WriteLine("=====================");
            if (isNot != null && isNot.Length != 0)
            {
                for (int i = 0; i < isNot.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {isNot[i].Task}");
                }
            } else
            {
                Console.WriteLine("You don't have any task yet.");
            }

            Console.WriteLine("=====================");

            Console.WriteLine("a. add Task");
            Console.WriteLine("b. change Task");
            Console.WriteLine("c. delete Task");
            Console.WriteLine("d. done Task");

            Console.WriteLine("=====================");

            Console.Write("Please select key: ");

            var choice = Console.ReadKey();

            switch(choice.Key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    AddView();
                    break;

                case ConsoleKey.B:
                    Console.Clear();
                    changeView();
                    break;

                case ConsoleKey.C:
                    Console.Clear();
                    IsDoneView();
                    break;

                case ConsoleKey.D:
                    Console.Clear();
                    AllDoneView();
                    break;
            }
        }


        private bool AddView()
        {
            _fieldValidator.FieldArray[(int)FieldConstants.TODO.Task] = GetInputUserTodo(FieldConstants.TODO.Task, "Please enter your task: ");
            _fieldValidator.FieldArray[(int)FieldConstants.TODO.VerifyId] = Temp.user.VeridyId;

            _todo.addTodo(_fieldValidator.FieldArray);


            CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
            Console.WriteLine("Success to add todo!");
            CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

            Console.ReadKey();
            Console.Clear();
            RunView();


            return true;
        }

        private bool changeView()
        {
            
            try
            {
                int i = InputInteger("Enter the task id: ");
                string v = InputUtil.GetInputUser("Enter the value: ");

                _todo.changeTodo(isNot[i - 1].Id, v);

                CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
                Console.WriteLine("Success to add todo!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            } catch
            {

                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);
                Console.WriteLine("The value id is not found!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            }



            Console.ReadKey();
            Console.Clear();
            RunView();


            return true;
        }

        private bool IsDoneView()
        {

            try
            {
                int i = InputInteger("Enter the task id: ");

                _todo.isDoneTodo(isNot[i - 1].Id);

                CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
                Console.WriteLine("This task now is completed!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            }
            catch
            {

                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);
                Console.WriteLine("The value id is not found!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            }



            Console.ReadKey();
            Console.Clear();
            RunView();


            return true;
        }


        private bool FieldValid(FieldConstants.TODO field, string fieldValue)
        {
            if (!_fieldValidator.ValidatorGate((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);

                Console.WriteLine(invalidMessage);

                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

                return false;
            }
            return true;
        }

        private void AllDoneView()
        {

            Console.WriteLine("=====================");
            if (isDone != null && isDone.Length != 0)
            {
                for (int i = 0; i < isDone.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {isDone[i].Task}");
                }
            }
            else
            {
                Console.WriteLine("You don't have any done task yet.");
            }

            Console.WriteLine("=====================");

            Console.ReadKey();

            Console.Clear();
            RunView();
        }

        public string GetInputUserTodo(FieldConstants.TODO field, string prompt)
        {
            string fieldValid = "";

            do
            {
                Console.Write(prompt);
                fieldValid = Console.ReadLine();
            } while (!FieldValid(field, fieldValid));

            return fieldValid;
        }

        public static int InputInteger(String s)
        {
            while (true)
            {
                try
                {
                    Console.Write(s);
                    int e = int.Parse(Console.ReadLine());
                    return e;
                }
                catch
                {
                    Console.WriteLine($"the value that your input is not a number");
                }
            }
        }
    }
}
