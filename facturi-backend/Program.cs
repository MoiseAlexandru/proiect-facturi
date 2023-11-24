using facturi_backend.Data;
using facturi_backend.Helper.Seeders;
using facturi_backend.Repositories.DetaliiFacturaRepository;
using facturi_backend.Repositories.FacturaRepository;
using facturi_backend.Services.DetaliiFacturaService;
using facturi_backend.Services.FacturaService;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});


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

// Seeders
builder.Services.AddScoped<FacturiSeeder>();

var app = builder.Build();
SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<FacturiSeeder>();
        service.SeedFacturiInitiale();
    }
}
