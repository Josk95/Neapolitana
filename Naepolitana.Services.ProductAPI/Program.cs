using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naepolitana.Services.ProductAPI;
using Naepolitana.Services.ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllers();

ApplyMigrations();


app.Run();


void ApplyMigrations()
{
    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (db.Database.GetPendingMigrations().Count() > 0)
    {
        db.Database.Migrate();
    }
}


// Create Scope
// Get db class from Scope. 
// Check for pendin migrations
// if so...perform migrations

