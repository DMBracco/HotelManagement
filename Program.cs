using HotelManagement;
using HotelManagement.BLL.IServices;
using HotelManagement.BLL.Services;
using HotelManagement.DAL.EF;
using HotelManagement.DAL.Entities;
using HotelManagement.DAL.IRepositories;
using HotelManagement.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnectionMSSQL"); ;

builder.Services.AddDbContext<HotelContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<HotelContext>(); ;

builder.Services.AddScoped<IGenericRepository<Client>, EFGenericRepository<Client>>();
builder.Services.AddScoped<IGenericRepository<Room>, EFGenericRepository<Room>>();
builder.Services.AddScoped<IGenericRepository<TypeOfRoom>, EFGenericRepository<TypeOfRoom>>();
builder.Services.AddScoped<IGenericRepository<TypeOfStatus>, EFGenericRepository<TypeOfStatus>>();
builder.Services.AddScoped<IStatusRoomService, StatusRoomService>();
builder.Services.AddScoped<IGenericRepository<StatusRoom>, EFGenericRepository<StatusRoom>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

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
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
