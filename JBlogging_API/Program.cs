using JBlogging_API.Configurations;
using JBlogging_API.DTOs.Category;
using JBlogging_API.Models;
using JBlogging_API.Repositories.IRepository;
using JBlogging_API.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//config dbcontext
builder.Services.AddDbContext<JbloggingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JBloggingConnectionString")));

//config AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

//config Repository
builder.Services.AddScoped<IGeneralRepository<CategoryDTO>, CategoryRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
