using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprache;
using TodoList.database;

namespace TodoList.todolist
{
    public static class TodoListEndpoints
    {
        public static void AddRoutesTodoList(this WebApplication app ){
            
            var group = app.MapGroup("Task");

            //Create a task
            group.MapPost("/", async (AddTaskRequest req, AppDbContext context) =>
            {
                var exists = await context.TodoElements.AnyAsync(task => task.Title == req.title);

                if(exists){
                    return Results.Conflict("There is already a task with that name");
                }
                //At some point create exception classes
                //if(req.title == null || req.subtite == null){
                //}

                var new_Task = new TodoElement(req.title, req.subtitle);

                try{
                await context.TodoElements.AddAsync(new_Task);
                await context.SaveChangesAsync();
                }

                catch(Exception e ){
                    Console.WriteLine(e);
                }

                var result_task = new TodoElementDto(req.title, req.subtitle);

                return Results.Ok(result_task);
              
            });

            // get all
            group.MapGet("", async (AppDbContext context)=>{
                 var students = await context.TodoElements.
                Where(task => task.Completed == false).
                Select(task => new TodoElementGetDto(task.Id.ToString(),task.Title, task.SubTitle,task.Completed )).
                ToListAsync();

                return Results.Ok(students);
            });

            //get with Id
            group.MapGet("/{id:guid}",async (Guid id, AppDbContext context)=>{
                var task = await context.TodoElements.SingleOrDefaultAsync(task => task.Id == id);

                if(task == null){
                    return Results.BadRequest("This task don't exists");
                }

                TodoElementDto result_task= new(task.Title, task.SubTitle);

                return Results.Ok(result_task);
            });

            //Put task with id
            group.MapPut("/{id:guid}",async (AddTaskRequest req, Guid id, AppDbContext context)=>{
                var task = await context.TodoElements.SingleOrDefaultAsync(task => task.Id == id);

                if(task == null){
                    return Results.BadRequest("This task don't exists");
                }

                task.ChangeName(req.title, req.subtitle);
                await context.SaveChangesAsync();


                TodoElementDto result_task= new(task.Title, task.SubTitle);

                return Results.Ok(result_task);
            });

            //Delet task
            group.MapDelete("/{id:guid}",async (Guid id, AppDbContext context)=>{

                var task = await context.TodoElements.SingleOrDefaultAsync(task => task.Id == id);

                if(task == null){
                    return Results.BadRequest("This task don't exists");
                }

                task.ChangeCompleted(true);
                await context.SaveChangesAsync();



                return Results.Ok("task deletada");
            });


        }
    }
}