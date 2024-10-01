using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.todolist
{
    public record AddTaskRequest(string title, string subtitle);
}