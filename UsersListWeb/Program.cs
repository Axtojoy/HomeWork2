using UsersList.Domain.Mock;
using UsersList.DAL.Mock.Data;
using UsersList.Domain.Postgree;
using UsersList.Domain.Repositories.Abstact;
using UsersListLogic;
using UsersListWeb.PostgresMigrate;
using Microsoft.EntityFrameworkCore;
using UsersList.DAL.EF.Repositories;
using UsersList.DAL.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();


builder.Services.AddScoped<UsersListService>();
builder.Services.AddScoped<TaskListService>();


var dbType = builder.Configuration["DbConfig:Type"];
switch (dbType)
{
    case "Postgres":
        var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
        PostgresMigrator.Migrate(connectionString);
        builder.Services.AddScoped<ITaskRepostitory, TaskPostgreRepository>(x => new TaskPostgreRepository(connectionString));
        builder.Services.AddScoped<IUserRepostitory, UserPostgreRepository>(x => new UserPostgreRepository(connectionString));
        break;
    case "Mock":

        builder.Services.AddScoped<IUserRepostitory, UsersMockRepository>();
        builder.Services.AddScoped<ITaskRepostitory, TasksMockRepository>();


        builder.Services.AddSingleton<UserMockData>();
        builder.Services.AddSingleton<TasksMockData>();
        break;
    case "EF":
        var connectionStringEF = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
        PostgresMigrator.Migrate(connectionStringEF);

        builder.Services.AddDbContext<PostgreeContext>(
            options => options.UseNpgsql(connectionStringEF));


        builder.Services.AddScoped<ITaskRepostitory, TaskEFPostgreeRepository>();
        builder.Services.AddScoped<IUserRepostitory, UserEFPostgreeRepository>();
        break;

}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UsersList}/{action=ReviewUsersList}/{id?}");
app.MapControllerRoute(
    name: "blog",
    pattern: "{controller=TaskList}/{action=ReviewTasksList}/{id?}");

app.Run();
