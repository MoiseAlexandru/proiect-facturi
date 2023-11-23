using facturi_backend.Data;
using facturi_backend.Repositories.DetaliiFacturaRepository;
using facturi_backend.Repositories.FacturaRepository;
using facturi_backend.Services.DetaliiFacturaService;
using facturi_backend.Services.FacturaService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddTransient<IFacturaRepository, FacturaRepository>();
builder.Services.AddTransient<IDetaliiFacturaRepository, DetaliiFacturaRepository>();

// Services
builder.Services.AddTransient<IFacturaService, FacturaService>();
builder.Services.AddTransient<IDetaliiFacturaService, DetaliiFacturaService>();

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
