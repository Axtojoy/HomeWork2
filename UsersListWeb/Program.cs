using UsersList.DAL;
using UsersList.DAL.Repositories;
using UsersList.DAL.Repositories.Abstact;
using UsersListLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<IUserRepostitory, UsersRepository>();
builder.Services.AddScoped<ITaskRepostitory, TasksRepository>();

builder.Services.AddScoped<UsersListService>();
builder.Services.AddScoped<TaskListService>();

builder.Services.AddSingleton<UserMockData>();
builder.Services.AddSingleton<TasksMockData>();

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
