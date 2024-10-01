using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;

namespace TodoList.todolist
{
    public static class TodoListEndpoints
    {
        public static void AddRoutesTodoList(this WebApplication app ){
            Env.Load();
            //app.MapGroup("Task");
            app.MapGet("teste", () =>"foi" );
        }
    }
}