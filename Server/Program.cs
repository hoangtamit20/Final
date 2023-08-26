using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repositories.IRepository;
using Server.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add service automapper
builder.Services.AddAutoMapper(typeof(Program));

// add dbContext
builder.Services.AddDbContext<KhoaHocOnlineDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("strCon"));
});

// add IRepository Service
builder.Services.AddScoped<IRepositoryOfEntity<NguoiDungModel>, NguoiDungRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => {
    builder.AllowAnyHeader();
   builder.AllowAnyMethod();
   builder.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
