using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.todolist;

namespace TodoList.database
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration){
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string de conexão no appsettings.json na raiz do projeto pq essa bomba da peste não suporta .env de forma nativa e eu fiquei meia hora até entender que tem que colocar o caminho do arquivo no DotNet.Env().env().load()
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString,
                ServerVersion.AutoDetect("127.0.0.1"));
            base.OnConfiguring(optionsBuilder);
        }
        // coluna da tabela
        DbSet<TodoElement> TodoElements {get;set;}
    }
}