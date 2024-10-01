using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.todolist
{
    public record TodoElementGetDto(string Id, string Title, string SubTitle, Boolean completed);
     
    
}