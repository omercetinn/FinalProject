using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Autofac ile dependency and AOP desing
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host
    .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusinessModule()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//autofac, ninject, castlewindsor,structermap,light�nject,dry�nject -->Ioc Container
//autofac -->AOP Bir metodun �n�nde sonunda kod y�netimini sa�lar sunuyor
//en iyisi postsharp
//builder.Services.AddSingleton<IProductService,ProductManager>(); //arka planda referans olu�tur
//builder.Services.AddSingleton<IProductDal,EfProductDal>(); //arka planda referans olu�tur

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
