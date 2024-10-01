using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.todolist
{
    public static class TodoListEndpoints
    {
        public static void AddRoutesTodoList(this WebApplication app ){
            //app.MapGroup("Task");
            app.MapGet("teste", ()=> "chegou");
        }
    }
}