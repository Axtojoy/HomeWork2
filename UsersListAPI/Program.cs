using UsersList.DAL;
using UsersList.DAL.Repositories.Abstact;
using UsersList.DAL.Repositories;
using UsersListLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<IUserRepostitory, UsersRepository>();
builder.Services.AddScoped<ITaskRepostitory, TasksRepository>();

builder.Services.AddScoped<UsersListService>();
builder.Services.AddScoped<TaskListService>();

builder.Services.AddSingleton<UserMockData>();
builder.Services.AddSingleton<TasksMockData>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
