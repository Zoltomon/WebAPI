using WebAPI.Classes;
using WebAPI.Models;
using WebAPI.Interface;
using Microsoft.EntityFrameworkCore;
using WebAPI.Classes.POST;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<_1301123ZoltoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dataConnect")));
builder.Services.AddTransient<IUserPost, UserPostClass>();
builder.Services.AddTransient<IUser, UserClass>();

// Add services to the container.

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
app.UseAuthorization();

app.MapControllers();

app.Run();
