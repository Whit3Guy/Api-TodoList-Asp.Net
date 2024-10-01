using TodoList.database;
using TodoList.todolist;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();


// chave de acesso ao banco no appsettings.json
string connectionString = configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Database selecionado: {configuration.GetConnectionString("DefaultConnection")}");



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");  // Middleware CORS deve vir antes das rotas

app.AddRoutesTodoList();


//app.MapGet("app",  () => "hello World");

app.Run();

