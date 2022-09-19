using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService,ProductManager>();//new leme IoC direkt manager oluşturur. yani resolve hatası giderilir
//Singleton içinde data tutulmazsa kullanılır
//ödev AddScoped,AddTransient
builder.Services.AddSingleton<IProductDal,EfProductDal>();

//Autofac,Ninject v.. gibi yapılar otomatik IoC yapısı kurar ve kullanır

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
