using UsersList.DAL.Repositories.Abstact;
using UsersListLogic;
using UsersList.DAL.Mock.Data;
using UsersList.DAL.Mock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<IUserRepostitory, UsersMockRepository>();
builder.Services.AddScoped<ITaskRepostitory, TasksMockRepository>();

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
