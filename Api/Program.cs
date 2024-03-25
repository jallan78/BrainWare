using Api.Infrastructure;
using Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SimpleInjector;
using Container = SimpleInjector.Container; 

Container container = new();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(ConfigureLogger);

// Add services to the container.

// Required for constructor di with controllers
builder.Services.AddControllers().AddNewtonsoftJson();

// use simple injector
builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
});

// populate the container
container.Register<IOrderService, OrderService>();
DataComponentBootstrapper.Bootstrap(container);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("AppSettings:connectionString");
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureLogger(HostBuilderContext ctx, LoggerConfiguration loggerConfig)
{
    var appConfig = ctx.Configuration;
    string logPath = appConfig.GetValue<string>("AppSettings:LogFile");

    loggerConfig
        .MinimumLevel.Information()
        .WriteTo.Logger(lc => lc.WriteTo.File(logPath));
}
