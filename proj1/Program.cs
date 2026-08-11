using Microsoft.EntityFrameworkCore;
using proj1.Data;
using proj1.Repos;
using proj1.Entity;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using proj1.Service;
using proj1.Service.Person;
using proj1.Service.Family;
using proj1.Service.Business;
using proj1.Service.Relations;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and OpenAPI generation
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// AutoMapper kaydı eklensin:
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Program).Assembly);
});
// Use PostgreSQL (Docker). Connection string should be in appsettings.json under "ConnectionStrings:DefaultConnection"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepos<>), typeof(Repository<>));
builder.Services.AddScoped<IPersonService, PersonServices>();
builder.Services.AddScoped<IFamilyService, FamilyService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<IRelationsServices, RelationsServices>();

var app = builder.Build();

app.MapOpenApi();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
