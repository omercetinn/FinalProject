using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//autofac, ninject, castlewindsor,structermap,light�nject,dry�nject -->Ioc Container
//autofac -->AOP Bir metodun �n�nde sonunda kod y�netimini sa�lar sunuyor
builder.Services.AddSingleton<IProductService,ProductManager>(); //arka planda referans olu�tur
builder.Services.AddSingleton<IProductDal,EfProductDal>(); //arka planda referans olu�tur

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
