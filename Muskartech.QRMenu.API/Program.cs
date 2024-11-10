using Autofac;
using Autofac.Extensions.DependencyInjection;
using Muskartech.QRMenu.Application;
using Muskartech.QRMenu.Domain;
using Muskartech.QRMenu.Infrastructure;
using Muskartech.QRMenu.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Use Autofac as the DI container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DomainModule());
    containerBuilder.RegisterModule(new InfrastructureModule());
    containerBuilder.RegisterModule(new ApplicationModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();