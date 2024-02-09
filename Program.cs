using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using testSibers.Models;
using testSibers.Controllers.Commands.Projects.Validation;
using testSibers.Controllers.Commands.Tasks.Validation;
using testSibers.Controllers.Commands.Users.Validation;
using testSibers.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddTransient<UserUpdateCommandValidator>();
builder.Services.AddTransient<TaskUpdateCommandValidator>();
builder.Services.AddTransient<ProjectUpdateCommandValidator>();

builder.Services.AddDbContext<SystemDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISystemDbContext>(isp => isp.GetRequiredService<SystemDbContext>());

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddIdentityCore<User>(s =>
    {
        s.Password.RequireNonAlphanumeric = false;
        s.Password.RequireDigit = false;
    })
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
    .AddEntityFrameworkStores<SystemDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

Console.ReadLine();