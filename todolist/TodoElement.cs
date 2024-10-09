using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.todolist
{
    public class TodoElement
    {
        public Guid Id {get; private set;}
        public string Title {get;private set;}

        public string SubTitle {get; private set;}

        public bool Completed {get; private set;}

        public TodoElement(){}

        public TodoElement(string title, string subtitle){
            Title = title;
            SubTitle = subtitle;
            Completed =  false;
        }

        public void ChangeName(string title, string subtitle){
            Title = title;
            SubTitle = subtitle;
        }

        public void ChangeCompleted(bool x){
            Completed = x;
        }
    }
}
